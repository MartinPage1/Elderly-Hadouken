using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackwardsCharacterBehaviorP2 : MonoBehaviour
{
// Move player in 2D space
    public float maxSpeed = 5.4f;
    public float jumpHeight = 12f;
    public float gravityScale = 1.5f;
    public float maxHitPoints = 100f;
    public float hitPoints = 100f;
    public float powerPoints = 0f;
    public float maxPowerPoints = 100f;
    public Camera mainCamera;
    public float cooldown = 1f; //seconds
    private float lastAttackedAt = -9999f;
    
    AudioSource audioSource;
    public AudioClip scream;
    public GameObject weakShot;
    public GameObject weakShot2;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite walkingSprite;

    private Animator animator;

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
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        WeakAttack();
        // Movement controls
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && (isGrounded || Mathf.Abs(r2d.velocity.x) > 0.01f))
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
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
        }
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

       void OnCollisionEnter2D(Collision2D col)
    {
        //PlayerTwoBullet
        if(col.collider.gameObject.name == "PlayerOneBullet(Clone)"){
            hitPoints = hitPoints - 5f;
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
            animator.SetTrigger("isHit");
            audioSource.PlayOneShot(scream, 0.7F);
            //ChangeSprite();
        }
        if (hitPoints <= 0)
        {
            Destroy (gameObject);
        }
    }
}
