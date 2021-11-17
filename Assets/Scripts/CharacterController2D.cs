using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class CharacterController2D : MonoBehaviour
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
    public Transform firePoint;
    
    public Slider healthBar;
    public PlayerControls playerControls;
    AudioSource audioSource;
    public AudioClip scream;
    public GameObject weakShot;
    public GameObject weakShot2;
    public GameObject superLeft;
    public GameObject superRight;
    public GameObject currentPlayerTwo;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite walkingSprite;

    private Animator animator;

    bool flash = false;
    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
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
        healthBar = GameObject.FindGameObjectWithTag ("PlayerOneHealthSlider").GetComponent<Slider> ();

        playerControls = new PlayerControls();

        hitPoints = maxHitPoints;
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
        currentPlayerTwo = GameObject.FindGameObjectWithTag("Player 2");
        if (powerPoints == maxPowerPoints)
        {
            SuperAttack();
        }
        if(transform.position.y <= -5)
            {
             transform.position = new Vector3(transform.position.x, 6, transform.position.z);
            }
        if (hitPoints < 20 && !flash){
            characterFlash();
            flash = true;
        }

        // Movement controls
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))   // && (isGrounded || Mathf.Abs(r2d.velocity.x) > 0.01f)
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
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
            if (powerPoints >= maxPowerPoints)
            {
                powerPoints = maxPowerPoints;
            }
            
        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
                CreateDust();
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
                CreateDust();
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded || Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            r2d.AddForce(Vector2.up * jumpForce);
            //r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
            animator.SetTrigger("isJumping");
            Stretch();
            CreateDust();
        }
    }
    void HPTracker()
    {
        gM.UpdateHealthP1(hitPoints);
    }
    void PPTracker()
    {
        gM.UpdatePowerP1(powerPoints);
    }
    void WeakAttack()
    {
        //Shoot Right
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (Time.time > lastAttackedAt + cooldown){
                Instantiate(weakShot, transform.position + new Vector3(1f, 0, 0), transform.rotation);
                animator.SetTrigger("isAttacking");
                lastAttackedAt = Time.time;
            }
        }
        //Shoot Left
        else if(Input.GetKeyDown(KeyCode.Q))
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Time.time > lastAttackedAt + cooldown)
            {
                Instantiate(superLeft, transform.position + new Vector3(-1f, 0, 0), transform.rotation);
                animator.SetTrigger("isAttacking");
                lastAttackedAt = Time.time;
            }
        }
        //Shoot Left
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (Time.time > lastAttackedAt + cooldown)
            {
                Instantiate(superRight, transform.position + new Vector3(1f, 0, 0), transform.rotation);
                animator.SetTrigger("isAttacking");
                lastAttackedAt = Time.time;
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
        StartCoroutine(FlashSprite(GetComponent<SpriteRenderer>(), .2f, 1f, 1, 1));
    }
    public IEnumerator FlashSprite(SpriteRenderer renderer, float minAlpha, float maxAlpha, float interval, float duration)
    {
        Color colorNow = renderer.color;
        Color minColor = new Color(renderer.color.r, renderer.color.g, renderer.color.b, minAlpha);
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
    public void ArchieDamage()
    {
        if (Time.time > lastDamagedAt + .5f)
        {
            SendDamage(3f);
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
        SendDamage(7f);
        animator.SetTrigger("isHit");
        StartCoroutine("Pause");
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
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //PlayerTwoBullet
        if (col.collider.gameObject.name == "PlayerTwoBullet(Clone)" || col.collider.gameObject.name == "AlbertSuperP2(Clone)")
        {
            //hitPoints = hitPoints - 5f;
            CharacterTwoController2D opponent = currentPlayerTwo.GetComponent<CharacterTwoController2D>();
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
        if (col.collider.gameObject.tag == "BigDentureTwo")
        if (hitPoints <= 0)
        {
            Destroy (gameObject);
            gM.PlayerOneDied();
        }
    }
    void CreateDust()
    {
        dust.Play();
    }
}