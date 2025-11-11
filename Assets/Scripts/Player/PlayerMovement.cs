using UnityEngine;

using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{
   
    [SerializeField] private float moveSpeed = 5f;

   
    [SerializeField] private float jumpForce = 10f;



    
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;


   
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;


    //input variables

    // stores movement input values of the player (x and y)
    private Vector2 moveInput;

    private bool isGrounded;





    // Timer variables for walk sound

    // walkSoundTimer counts down to 0, when it reachees 0 we play the sound again
    private float walkSoundTimer = 0f;


    // walkSoundInterval is how many seconds bettween each footstep sound (0.3 = play sound every 0.3 seconds
    private float walkSoundInterval = 0.3f;


    void Start()

    {
        // get the components of the player GameObject
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    void Update()
    {
        // OverlapCircle creates an invisible circle at groundCheck position
        // If this circle touches anything in the groundLayer, returns true
        // check if player is touching the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        
        animator.SetBool("isJumping", !isGrounded); // updatee jump animation based on vertical velocity
    }


    void FixedUpdate()
    {


        // Move the player horizontally (left/right)
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);



        // Update animation based on movement

        // If moveInput.x is not zero, player is moving (left or right)
        if (moveInput.x != 0)
        {
            // Tell animator to play Walk animation
            animator.SetBool("isMoving", true);


            




            // Play walk sound only when player is moving AND on the ground
            if (isGrounded)


            {
                
                
                walkSoundTimer -= Time.fixedDeltaTime; //We subtract this time from our timer each frame


                // When timer reaches 0 or belkow, play the sound
                if (walkSoundTimer <= 0f)
                {
                    AudioManager.Instance.PlayWalkSound(); // play footstep sound
                    walkSoundTimer = walkSoundInterval; //reset timer back to 0.3 seconds
                }
            }



            // Flip sprite depending on direction
            // moveInput.x > 0 means moving right, < 0 means moving left
            if (moveInput.x > 0)

                spriteRenderer.flipX = false; // Face right (normal sprite)
            else
                spriteRenderer.flipX = true;  // Face left (flipped sprite)
        }
        else
        {
            // Player is not moving, play Idle animation
            animator.SetBool("isMoving", false);
        }
    }




    // this function is called by the new input system when Move action happens
    public void OnMove(InputAction.CallbackContext context)

    {
        // read the input value (Vector2 with x And y)

        moveInput = context.ReadValue<Vector2>();
    }





    // This function is called by the new Input System when Jump action happens

    public void OnJump(InputAction.CallbackContext context)

    {
        // Only jump if button was pressed (not held) and player is on ground

        if (context.performed && isGrounded)

        {

            // jump sound before applying jump force
            AudioManager.Instance.PlayJumpSound();


            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // apply jump force to the player   

        }
    }
}