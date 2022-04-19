using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class CharacterTwoController2D : MonoBehaviour
{
    // Move player in 2D space
    public ParticleSystem dust;
    public float maxSpeed = 8.4f;
    public float jumpHeight = 12f;
    public float jumpForce = 550f;
    public float gravityScale = 1.5f;
    public float maxHitPoints = 100f;
    public float hitPoints = 100f;
    public float powerPoints = 0f;
    public float maxPowerPoints = 100f;
    public Camera mainCamera;
    public float cooldown = 1f; //seconds
    private float lastAttackedAt = -9999f;
    private float lastDamagedAt = -9999f;
    public GameManager gM;
    bool grabbed = false;
    bool block = false;
    bool canBlock = true;

    public Slider healthBar;

    private PlayerControls playerControls; 
    private PlayerInput playerInput;
    private InputAction jumpAction;
    private InputAction moveRightAction;
    private InputAction moveLeftAction;


    AudioSource audioSource;
    public AudioClip scream;
    public AudioClip blockSound;
    public GameObject weakShot;
    public GameObject weakShot2;
    public GameObject superLeft;
    public GameObject superRight;
    public GameObject currentPlayerOne;
    public GameObject dustTrail;
    public GameObject dustLanding;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite walkingSprite;

    private Animator animator;

    bool flash = false;
    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    private Vector2 moveInput;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;

    // Use this for initialization
    void Awake()
    {
        dust = GetComponentInChildren<ParticleSystem>();
        t = transform;
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        healthBar = GameObject.FindGameObjectWithTag ("PlayerTwoHealthSlider").GetComponent<Slider> ();

        currentPlayerOne = GameObject.FindGameObjectWithTag("Player");

        playerInput = GetComponent<PlayerInput>();
        jumpAction = playerInput.actions["Jump"];
        jumpAction.ReadValue<float>();
        moveRightAction = playerInput.actions["MoveRight"];
        moveRightAction.ReadValue<float>();
        moveLeftAction = playerInput.actions["MoveLeft"];
        moveLeftAction.ReadValue<float>();
        //hitPoints = maxHitPoints;
        healthBar.value = hitPoints;
        healthBar.maxValue = maxHitPoints;
        jumpForce = 550f;
        maxSpeed = 8.4f;
        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HPTracker();
        PPTracker();
        WeakAttack();
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
            gM.PlayerTwoDied();
        }
        if (powerPoints <= 0)
        {
            powerPoints = 0;
        }
        if (powerPoints >= 100)
        {
            powerPoints = 100;
        }
        if (grabbed == true)
        {
            animator.SetTrigger("isHit");
        }
        if (powerPoints >= maxPowerPoints)
        {
            SuperAttack();
        }
        currentPlayerOne = GameObject.FindGameObjectWithTag("Player");

        var gamepad = Gamepad.current;
        if (transform.position.y <= -5)
            {
             transform.position = new Vector3(transform.position.x, 6, transform.position.z);
            }
        if (transform.position.x <= -8.99f)
        {
            transform.position = new Vector3(-8.99f, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= 9.1)
        {
            transform.position = new Vector3(9, transform.position.y, transform.position.z);
        }
        if (hitPoints < 20 && !flash){
            characterFlash();
            flash = true;
        }
        //Vector2 move = playerControls.GameplayP2.Move.ReadValue<Vector2>();
        // Movement controls
        // moveLeftAction.triggered || moveRightAction.triggered
        if (Input.GetKey(KeyCode.LeftArrow) && grabbed == false || Input.GetKey(KeyCode.RightArrow) && grabbed == false || gamepad.dpad.left.isPressed && grabbed == false || gamepad.dpad.right.isPressed && grabbed == false)   // && (isGrounded || Mathf.Abs(r2d.velocity.x) > 0.01f)
        {
            moveDirection = Input.GetKey(KeyCode.LeftArrow) ? -1 : 1;
            moveDirection = gamepad.dpad.left.isPressed ? -1 : 1;
            animator.SetBool("isWalking", true);
        }
        else
        {
            if (isGrounded || r2d.velocity.magnitude < 0.01f)
            {
                moveDirection = 0;
                animator.SetBool("isWalking", false);
            }
        }
        // Power Points max stay at max
        //if (powerPoints >= maxPowerPoints)
        //{
        //    powerPoints = maxPowerPoints;
        //}

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
               // CreateDust();
                CreateDustTrail();
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
                //CreateDust();
                CreateDustTrail();
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded && grabbed == false || jumpAction.triggered && isGrounded && grabbed == false)
        {            
            r2d.AddForce(Vector2.up * jumpForce);
            //r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
            animator.SetTrigger("isJumping");
            Stretch();
            //CreateDust();
            CreateDustLanding();
        }
    }
    void HPTracker()
    {
        gM.UpdateHealthP2(hitPoints);
    }
    void PPTracker()
    {
        gM.UpdatePowerP2(powerPoints);
    }
    void WeakAttack()
    {
        var gamepad = Gamepad.current;
        //Shoot Right
        if (Input.GetKeyDown(KeyCode.Period) || gamepad.rightShoulder.wasPressedThisFrame || gamepad.buttonEast.wasPressedThisFrame)
        {
            if (Time.time > lastAttackedAt + cooldown){
                Instantiate(weakShot, transform.position + new Vector3(1f, 0, 0), transform.rotation);
                animator.SetTrigger("isAttacking");
                lastAttackedAt = Time.time;
            }
        }
        //Shoot Left
        else if(Input.GetKeyDown(KeyCode.Comma) || gamepad.leftShoulder.wasPressedThisFrame || gamepad.buttonWest.wasPressedThisFrame)
        {
            if (Time.time > lastAttackedAt + cooldown){
                Instantiate(weakShot2, transform.position + new Vector3(-1f, 0, 0), transform.rotation);
                animator.SetTrigger("isAttacking");
                lastAttackedAt = Time.time;
            }
        }
    }
    void SuperAttack()
    {
        var gamepad = Gamepad.current;
        if (gamepad.rightTrigger.wasPressedThisFrame)
        {
            if (Time.time > lastAttackedAt + cooldown)
            {
                Instantiate(superLeft, transform.position + new Vector3(1f, 0, 0), transform.rotation);
                animator.SetTrigger("isAttacking");
                lastAttackedAt = Time.time;
                powerPoints = 0;
            }
        }
        //Shoot Left
        else if (gamepad.leftTrigger.wasPressedThisFrame)
        {
            if (Time.time > lastAttackedAt + cooldown)
            {
                Instantiate(superRight, transform.position + new Vector3(-1f, 0, 0), transform.rotation);
                animator.SetTrigger("isAttacking");
                lastAttackedAt = Time.time;
                powerPoints = 0;
            }
        }
    }
    public void getPP(float number)
    {
        if (powerPoints < maxPowerPoints)
        {
            powerPoints = powerPoints + number;
        }
        else if (powerPoints >= maxPowerPoints)
        {
            powerPoints = maxPowerPoints;
        }
    }
    void Stretch()
    {
        float strechTime = 0.2f;
        t.localScale = new Vector3(transform.localScale.x, transform.localScale.y + strechTime, 0);
        StartCoroutine("UnStretch");
    }
    private IEnumerator UnStretch()
    {
        float stretchEndTime = Time.realtimeSinceStartup + .5f;
        while (Time.realtimeSinceStartup < stretchEndTime)
        {
            yield return 0;
        }
        t.localScale = new Vector3(transform.localScale.x, transform.localScale.y - 0.2f, 0);
    }
    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    break;
                }
            }
        }

        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);

        // Simple debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), isGrounded ? Color.green : Color.red);
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), isGrounded ? Color.green : Color.red);
    }
    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite; 
    }
    private IEnumerator Pause()
    {
        Time.timeScale = 0.01f;
        float pauseEndTime = Time.realtimeSinceStartup + .2f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
    }
    public void SendDamage(float damageValue)
    {
        hitPoints -= damageValue;
        healthBar.value = hitPoints;
        //animator.SetFloat("hit", 1);
    }
    void characterFlash()
    {
        StartCoroutine(FlashSprite(GetComponent<SpriteRenderer>(), .2f, 1f, 1, 2));
    }
    public IEnumerator FlashSprite(SpriteRenderer renderer, float minAlpha, float maxAlpha, float interval, float duration)
    {
        Color colorNow = renderer.color;
        Color minColor = new Color(renderer.color.r, .2f, .2f, minAlpha);
        Color maxColor = new Color(renderer.color.r, renderer.color.g, renderer.color.b, maxAlpha);

        float currentInterval = 0;
        while(duration > 0)
        {
            float tColor = currentInterval / interval;
            renderer.color = Color.Lerp(minColor, maxColor, tColor);

            currentInterval += Time.deltaTime;
            if(currentInterval >= interval)
            {
                Color temp = minColor;
                minColor = maxColor;
                maxColor = temp;
                currentInterval = currentInterval - interval;
            }
            duration -= Time.deltaTime;
            yield return null;
        }
        renderer.color = colorNow;
        flash = false;
    }
    private void OnEnable()
    {
        jumpAction.Enable();
        moveLeftAction.Enable();
        moveRightAction.Enable();
    }
    private void OnDisable()
    {
        jumpAction.Disable();
        moveLeftAction.Disable();
        moveRightAction.Disable();
    }
    public void ArchieDamage()
    {
        if (Time.time > lastDamagedAt + 1f)
        {
            SendDamage(4f);
            animator.SetTrigger("isHit");
            //StartCoroutine("Pause");
            CameraShake.Shake(0.25f, 0.25f);
            if (powerPoints < maxPowerPoints)
            {
                powerPoints = powerPoints + 7f;
            }
            else if (powerPoints >= maxPowerPoints)
            {
                powerPoints = maxPowerPoints;
            }
            audioSource.PlayOneShot(scream, 0.7F);
            if (hitPoints <= 0)
            {
                Destroy(gameObject);
                gM.PlayerTwoDied();
            }
            lastDamagedAt = Time.time;
        }
    }
    public void EdithDamage()
    {
        if (Time.time > lastDamagedAt + 1f)
        {
            SendDamage(8f);
            //animator.SetTrigger("isHit");
            //StartCoroutine("Pause");
            CameraShake.Shake(0.25f, 0.25f); 
            if (powerPoints < maxPowerPoints)
            {
                powerPoints = powerPoints + 7f;
            }
            else if (powerPoints >= maxPowerPoints)
            {
                powerPoints = maxPowerPoints;
            }
            audioSource.PlayOneShot(scream, 0.7F);
            if (hitPoints <= 0)
            {
                Destroy(gameObject);
                gM.PlayerTwoDied();
            }
            lastDamagedAt = Time.time;
        }
    }
    public void BettyDamage()
    {
        if (Time.time > lastDamagedAt + .2f)
        {
            SendDamage(5f);
            animator.SetTrigger("isHit");
            StartCoroutine("Pause");
            //CameraShake.Shake(0.25f, 0.25f);
            if (powerPoints < maxPowerPoints)
            {
                powerPoints = powerPoints + 7f;
            }
            else if (powerPoints >= maxPowerPoints)
            {
                powerPoints = maxPowerPoints;
            }
            audioSource.PlayOneShot(scream, 0.7F);
            if (hitPoints <= 0)
            {
                Destroy(gameObject);
                gM.PlayerTwoDied();
            }
            lastDamagedAt = Time.time;
        }
    }
    public void GertieDamage()
    {
        if (Time.time > lastDamagedAt + 1f)
        {
            grabbed = true;
            SendDamage(5f);
            //animator.SetTrigger("isHit");
            //StartCoroutine("Pause");
            CameraShake.Shake(0.25f, 0.25f);
            if (powerPoints < maxPowerPoints)
            {
                powerPoints = powerPoints + 7f;
            }
            else if (powerPoints >= maxPowerPoints)
            {
                powerPoints = maxPowerPoints;
            }
            audioSource.PlayOneShot(scream, 0.7F);
            if (hitPoints <= 0)
            {
                Destroy(gameObject);
                gM.PlayerOneDied();
            }
            lastDamagedAt = Time.time;
        }
    }
    public void PigeonDamage()
    {
        if (Time.time > lastDamagedAt + 4f)
        {
            SendDamage(3f);
            animator.SetTrigger("isHit");
            StartCoroutine("Pause");
            //CameraShake.Shake(0.25f, 0.25f);
            if (powerPoints < maxPowerPoints)
            {
                powerPoints = powerPoints + 2f;
            }
            else if (powerPoints >= maxPowerPoints)
            {
                powerPoints = maxPowerPoints;
            }
            audioSource.PlayOneShot(scream, 0.7F);
            if (hitPoints <= 0)
            {
                Destroy(gameObject);
                gM.PlayerTwoDied();
                lastDamagedAt = Time.time;
            }
        }
    }
    public void DentureDamage()
    {
        if (Time.time > lastDamagedAt + .2f)
        {
            CharacterController2D opponent = currentPlayerOne.GetComponent<CharacterController2D>();
            grabbed = true;
            transform.position += new Vector3(Random.Range(-1f, 1f), 0.0f, 0.0f) * Time.deltaTime * maxSpeed;

            if (opponent != null)
            {
                opponent.getPP(7f);
            }
            SendDamage(6f);
            CameraShake.Shake(0.15f, 0.15f);
            animator.SetTrigger("isHit");
            //StartCoroutine("Pause");
            audioSource.PlayOneShot(scream, 0.7F);
            lastDamagedAt = Time.time;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //PlayerOneBullet
        if (col.collider.gameObject.name == "PlayerOneBullet(Clone)" && block == false || col.collider.gameObject.name == "AlbertSuperP1(Clone)" && block == false)
        {
            //hitPoints = hitPoints - 5f;
            CharacterController2D opponent = currentPlayerOne.GetComponent<CharacterController2D>();
            if (opponent != null)
            {
                opponent.getPP(7f);
            }
            SendDamage(5f);
            CameraShake.Shake(0.15f, 0.15f);
            animator.SetTrigger("isHit");
            StartCoroutine("Pause");
            getPP(10f);
           // hitPoints--;
            Destroy (col.collider.gameObject);
            audioSource.PlayOneShot(scream, 0.7F);
            //ChangeSprite();
        }
        else if (col.collider.gameObject.name == "PlayerOneBullet(Clone)" && block == true && powerPoints > 0 || col.collider.gameObject.name == "AlbertSuperP1(Clone)" && block == true && powerPoints > 0)
        {
            Destroy(col.collider.gameObject);
            StartCoroutine("Pause");
            powerPoints = powerPoints - 25;
            audioSource.PlayOneShot(blockSound, 0.7F);
        }
        if (col.collider.gameObject.tag == "Pigeon")
        {
            SendDamage(5f); 
            animator.SetTrigger("isHit");
            //artCoroutine("Pause");
            getPP(2f);
            audioSource.PlayOneShot(scream, 0.7F);
        }
        if (col.collider.gameObject.tag == "BigDentureOne")
        {
            if (Time.time > lastDamagedAt)
            {
                CharacterTwoController2D opponent = currentPlayerOne.GetComponent<CharacterTwoController2D>();
                grabbed = true;
                transform.position += new Vector3(Random.Range(-1f, 1f), 0.0f, 0.0f) * Time.deltaTime * maxSpeed;

                if (opponent != null)
                {
                    opponent.getPP(7f);
                }
                SendDamage(6f);
                CameraShake.Shake(0.15f, 0.15f);
                animator.SetTrigger("isHit");
                //StartCoroutine("Pause");
                audioSource.PlayOneShot(scream, 0.7F);
                lastDamagedAt = Time.time;
            }

            if (hitPoints <= 0)
            {
                Destroy(gameObject);
                gM.PlayerOneDied();
            }

        }
        if (col.collider.gameObject.tag == "Pap")
        {
            SendDamage(5f);
            getPP(2f);
            Destroy(col.collider.gameObject); 
            animator.SetTrigger("isHit");
            audioSource.PlayOneShot(scream, 0.7F);
        }
        if (hitPoints <= 0)
        {
            Destroy (gameObject);
            gM.PlayerTwoDied();
        }
    }
    public void GrabToggle()
    {
        if (grabbed == true)
        {
            grabbed = false;
        }
        //if (grabbed == false)
        // {
        //    grabbed = true;
        // }
    }
    void CreateDust()
    {
        dust.Play();
    }
    void CreateDustTrail()
    {
        Instantiate(dustTrail, transform.position + new Vector3(0, -.7f, 0), transform.rotation);
    }
    void CreateDustLanding()
    {
        Instantiate(dustLanding, transform.position + new Vector3(-.4f, 0, 0), transform.rotation);
    }
}
