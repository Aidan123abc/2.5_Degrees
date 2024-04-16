using UnityEngine;

public class SquirrelController : MonoBehaviour
{
    //Movement Vairables
    private Animator animator;
    private bool FaceRight = true; 
    public float runSpeed = 10f;
	public GameHandler gameHandler;

    //Jumping Variables
    private Rigidbody2D rb;
    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayer;
    public LayerMask enemyLayer; 
    public bool canJump = false; 
    public int jumpTimes = 0; 
    public bool isAlive = true;

    //Ladder Variables
    private float vertical;
    private float speed = 4f;
    private bool isLadder;
    private bool isClimbing;

    void Start()
    {
        //Get squirrel art file for animations
        Transform childTransform = transform.Find("squirrel_art");
        if (childTransform != null)
        {
            //Get animator  
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
    if (isAlive) {
    // Movement Conditions
    Vector3 hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
    transform.position += hMove * runSpeed * Time.deltaTime;

    // Walking animations    
    if (hMove.x != 0){
        animator.SetBool("Walk", true);
    } else {
        animator.SetBool("Walk", false);
    }

    if ((hMove.x < 0 && !FaceRight) || (hMove.x > 0 && FaceRight))
    {
        Turn();
    }

    // Jumping Conditions using Vertical axis
    if (IsGrounded() && Input.GetAxis("Vertical") > 0 && jumpTimes <= 1 && isAlive) 
    { 
        Jump();
        canJump = true;
        animator.SetBool("Fly", false);
    } 
    else
    {
        canJump = false;
        animator.SetBool("Fly", true);
    }
    if(IsGrounded()){
        animator.SetBool("Fly", false);
    }

    // Ladder Conditions (no changes needed here)
    vertical = Input.GetAxisRaw("Vertical");
    if (isLadder && Mathf.Abs(vertical) > 0f)
    {
        isClimbing = true;
    }

    // 'E' eats acorns (no changes needed here)
    if (Input.GetKeyDown(KeyCode.E)) {
        if(gameHandler.getAcornCount() > 0){
            animator.SetTrigger("Eat");   
        }
    }
    //  Scratch animation
    if (Input.GetKeyDown(KeyCode.Space))
    {
        animator.SetTrigger("Scratch");
    }
    }
}

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void Turn()
	{
		// Switch player facing label
		FaceRight = !FaceRight;

		// Multiply player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    void Jump() {
            jumpTimes += 1;
            rb.velocity = Vector2.up * jumpForce;
            // anim.SetTrigger("Jump");
            // JumpSFX.Play();

            //Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
            //rb.velocity = movement;
    } 

    bool IsGrounded() { 
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer);
        Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, 0.5f, enemyLayer);
        if (groundCheck != null) //|| (enemyCheck != null)) 
        { 
                // Debug.Log("I am trouching ground!");
                jumpTimes = 0;
                return true;
        }
        return false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }

    public void SquirrelDies(){
        Debug.Log("DIEEEE");
        isAlive = false;
        animator.SetTrigger("Die");
    }
}
