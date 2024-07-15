using UnityEngine;

public class NewMovement : MonoBehaviour
{
    
    public LayerMask obstacleLayer;
    public GameObject roadPrefab; 

    public float obstacleCheckDistance = 2f;
    private bool isGameOver = false;

    public float jumpForce = 10f;
    public float slideForce = 5f;
    public float laneWidth = 3f;

    private Rigidbody rb;
    private Animator animator;

    private int currentLane = 1;

    private bool isJumping = false;
    private bool isSliding = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && currentLane > 0)
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentLane < 2)
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.S) && !isSliding)
        {
            Slide();
        }

        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsSliding", isSliding);

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, rb.velocity.y);
    }

    private void MoveLeft()
    {
        currentLane--;
        transform.position = new Vector3(transform.position.x - laneWidth, transform.position.y, transform.position.z);
    }

    private void MoveRight()
    {
        currentLane++;
        transform.position = new Vector3(transform.position.x + laneWidth, transform.position.y, transform.position.z);
    }

    private void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Slide()
    {
        isSliding = true;
        rb.velocity = new Vector3(rb.velocity.x, -slideForce, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isJumping)
        {
            isJumping = false;
        }

        
        
        GameOver();
        
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (isSliding)
        {
            isSliding = false;
        }
    }

  

    private void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;  
            Debug.Log("Lose");           
        }
    }
}