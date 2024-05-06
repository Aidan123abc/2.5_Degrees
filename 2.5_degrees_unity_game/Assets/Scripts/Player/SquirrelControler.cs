using UnityEngine;
using System.Collections; 

public class SquirrelController : MonoBehaviour
{
    // Movement Variables
    private Animator animator;
    private bool FaceRight = true; 
    public float runSpeed = 10f;
    public GameHandler gameHandler;
    public MenuHandler menuHandler;
    public Transform respawnPosition;

    // Jumping Variables
    private Rigidbody2D rb;
    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayer;
    public LayerMask enemyLayer; 
    public bool canJump = false;
    public int jumpTimes = 0; 
    public bool isAlive = true;
    private bool jumpBlocker = false;
    //public float jumpCooldown = 0.1f;  // Cooldown duration in seconds
    private float jumpCooldown = 0.1f;  // Timer to track cooldown


    // Ladder Variables
    private float vertical;
    private float speed = 4f;
    private bool isLadder;
    private bool isClimbing;

    void Start()
    {
        Transform childTransform = transform.Find("squirrel_art");
        if (childTransform != null)
        {
            animator = childTransform.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Child object with Animator not found!");
        }
        rb = GetComponent<Rigidbody2D>();
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }

    void Update()
    {
        if (!isAlive) return;

        HandleMovement();
        HandleAnimation();
        CheckClimbing();
        ProcessInputs();
    }

    void HandleMovement()
    {
        Vector3 hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position += hMove * runSpeed * Time.deltaTime;

        if ((hMove.x > 0 && FaceRight) || (hMove.x < 0 && !FaceRight))
        {
            Turn();
        }
    }

    void HandleAnimation()
    {
        animator.SetBool("Walk", Input.GetAxis("Horizontal") != 0);
        animator.SetBool("Fly", !IsGrounded());
    }

    void CheckClimbing()
    {
        vertical = Input.GetAxisRaw("Vertical");
        if (isLadder)
        {
            isClimbing = true;
            rb.gravityScale = 0;
            if(Mathf.Abs(vertical) > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
                animator.SetBool("ClimbLadder", true);
            }
        }
        else
        {
            isClimbing = false;
            rb.gravityScale = 1;
            animator.SetBool("ClimbLadder", false);
        }
    }

    void ProcessInputs()
    {
        // Check for climbing before jumping
        if (isClimbing) return;  // If climbing, do not process jumping

        if (IsGrounded() && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && jumpTimes < 2 && canJump && !isClimbing)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E) && gameHandler.getAcornCount() > 0)
        {
            animator.SetTrigger("Eat");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Scratch");
        }
    }

    void Turn()
    {
        FaceRight = !FaceRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        canJump = false;
        // jumpTimes++;
        jumpBlocker = true; 
        StartCoroutine(JumpCooldown());  // Start cooldown coroutine
        if (++jumpTimes >= 2) jumpTimes = 0;
        jumpBlocker = false; 
    
    }

    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);  // Wait for the cooldown period
    }

    bool IsGrounded()
    { 
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.15f, groundLayer);
        if (groundCheck != null)
        { 
            jumpTimes = 0;
            // canJump = true;
            if (!jumpBlocker) {
                canJump = true;
            }
            return true;
        }

        return false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            canJump = false;
        }
        else if (collision.CompareTag("Respawn"))
        {
            HandleRespawn();
        }
        else if (collision.CompareTag("EndLevelTag"))
        {
            // menuHandler.PauseMenuHandler.OpenMap();
        }
        else if (collision.CompareTag("Checkpoint"))
        {
            CheckpointScript checkpoint = collision.GetComponent<CheckpointScript>();
            if (!checkpoint) {
                Debug.LogError("Error no checkpoint script");
            } else {
                checkpoint.ActivateCheckpoint();
                respawnPosition.position = new Vector2(collision.transform.position.x + 1f, collision.transform.position.y);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            canJump = true;
        }
    }

    public void SquirrelDies()
    {
        isAlive = false;
        animator.SetTrigger("Die");
    }

    private void HandleRespawn()
    {
        transform.position = respawnPosition.position;
        isAlive = true;
        rb.velocity = Vector2.zero;
    }

    public void TriggerHurtAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Hurt");
        }
        else
        {
            Debug.LogError("Animator component not found on child object!");
        }
    }

    public void SquirrelEat()
    {
        if (animator != null)
        {
        animator.SetTrigger("Eat");
        }
    }
}
