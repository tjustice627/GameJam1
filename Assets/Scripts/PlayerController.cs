using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    float horizontal;
    float vertical;
    float invincibleTimer;
    bool isGrounded;
    bool touchingLadder;
    bool isClimbing;
    bool isInvincible;
    SceneChange sceneManager;
    string gameOverScene = "GameOver";

    public int maxHealth;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    public LayerMask ladderLayer;
    public float speed;
    public float jumpForce;
    public float distance;
    public float timeInvincible;
    public int currentHealth;
    public int enemiesRemaining;
    public int totalEnemies = 10;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        CheckIfGrounded();
        Climb();

        if (transform.position.y <= -10)
        {
            currentHealth = 0;
        }

        Vector2 move = new Vector2(horizontal, 0);
        
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, 0);
        }
                
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Move Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if (currentHealth <= 0) 
        {
            LoadScene(gameOverScene);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        float moveBy = horizontal * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void Climb()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, ladderLayer);

        if (hitInfo.collider != null)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                isClimbing = true;
            }
        } else {
            isClimbing = false;
        }

        

        if(isClimbing)
        {
            vertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            rb.gravityScale = 0;
            animator.SetBool("isClimbing", true);
        } else
        {
            rb.gravityScale = 1;
            animator.SetBool("isClimbing", false);
        }
    }

    void CheckIfGrounded()
    {
        Collider2D groundCollider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        Collider2D ladderCollider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, ladderLayer);

        if (groundCollider != null || ladderCollider != null)
        {
            isGrounded = true;
        } else {
            isGrounded = false;
        }
    }

    public void ChangeHealth(int amount) 
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        HealthBar.instance.SetValue(currentHealth/ (float)maxHealth);
    }
}
