using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTwoController2D : MonoBehaviour
{
    // Move player in 2D space
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
    public GameManager gM;

    public Slider healthBar;
    
    AudioSource audioSource;
    public AudioClip scream;
    public GameObject weakShot;
    public GameObject weakShot2;

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
    void Start()
    {
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
        if(transform.position.y <= -5)
            {
             transform.position = new Vector3(transform.position.x, 6, transform.position.z);
            }
        if (hitPoints < 20 && !flash){
            characterFlash();
            flash = true;
        }

        // Movement controls
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))   // && (isGrounded || Mathf.Abs(r2d.velocity.x) > 0.01f)
        {
            moveDirection = Input.GetKey(KeyCode.LeftArrow) ? -1 : 1;
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
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {            
            r2d.AddForce(Vector2.up * jumpForce);
            //r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
            animator.SetTrigger("isJumping");
            Stretch();
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
        //Shoot Right
        if(Input.GetKeyDown(KeyCode.Period))
        {
            if (Time.time > lastAttackedAt + cooldown){
                Instantiate(weakShot, transform.position + new Vector3(1f, 0, 0), transform.rotation);
                animator.SetTrigger("isAttacking");
                lastAttackedAt = Time.time;
            }
        }
        //Shoot Left
        else if(Input.GetKeyDown(KeyCode.Comma))
        {
            if (Time.time > lastAttackedAt + cooldown){
                Instantiate(weakShot2, transform.position + new Vector3(-1f, 0, 0), transform.rotation);
                animator.SetTrigger("isAttacking");
                lastAttackedAt = Time.time;
            }
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
       void OnCollisionEnter2D(Collision2D col)
    {
        //PlayerTwoBullet
        if(col.collider.gameObject.name == "PlayerOneBullet(Clone)"){
            //hitPoints = hitPoints - 5f;
            SendDamage(5f);
            CameraShake.Shake(0.15f, 0.15f);
            animator.SetTrigger("isHit");
            StartCoroutine("Pause");
            if (powerPoints < maxPowerPoints)
            {
                powerPoints = powerPoints + 7f;
            }
            else if (powerPoints >= maxPowerPoints)
            {
                powerPoints = maxPowerPoints;
            }
           // hitPoints--;
            Destroy (col.collider.gameObject);
            audioSource.PlayOneShot(scream, 0.7F);
            //ChangeSprite();
        }
        if (hitPoints <= 0)
        {
            Destroy (gameObject);
            gM.PlayerTwoDied();
        }
    }
}
