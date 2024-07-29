using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //variables
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float horizontalInput;
    private Rigidbody2D playerRb;
    private bool isOnGround;
    // Ground check parameters
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
    }
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        Jump();
    }
    private void PlayerMovement()
    {
        playerRb.velocity = new Vector2(horizontalInput * speed, playerRb.velocity.y);
    }
    private void Jump()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            playerRb.velocity = Vector2.up * jumpForce;
        }

    }
}