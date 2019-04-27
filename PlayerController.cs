using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    float jumpForce = 26f;
    public float runningSpeed = 1.6f;
    public Animator animator;


    private Rigidbody2D RG2D;
    public LayerMask groundLayer;
    private Vector3 startingPosition;

    void Jump()
    {
        if (IsGrounded())
        {
            RG2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool IsGrounded()
    {

        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer.value))
        {
            return true;
        }
        else
        {
            return false;
        }
    }




    void Awake()
    {
        instance = this;
        RG2D = GetComponent<Rigidbody2D>();
        startingPosition = this.transform.position; //Setting up the player starting position

    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isAlive", true);

    }


    // Update is called once per frame
    void Update()
    {
        //check if you'r playing 
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }
            // face reaction 
            animator.SetBool("isGrounded", IsGrounded());
        }

        switch (GameManager.instance.collectedCoins)
        {
            case 5:
                runningSpeed = 1.9f;
                break;
            case 10:
                runningSpeed = 2f;
                break;
            case 15:
                runningSpeed = 2.5f;
                break;

        }

    }
    void FixedUpdate()
    {
        //check if you'r playing 
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            // if the character's speed is slower than the running speed,
            // push him forward.
            if (RG2D.velocity.x < runningSpeed)
            {
                RG2D.velocity = new Vector2(runningSpeed, RG2D.velocity.y);
            }
        }
    }

    public void StartGame()
    {
        animator.SetBool("isAlive", true);
        this.transform.position = startingPosition;
    }

    public void Kill()
    {
        GameManager.instance.gameOver();

        animator.SetBool("isAlive", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {//0
        if (other.gameObject.CompareTag("killTrigger"))
        {
            PlayerController.instance.Kill();



        }
    }

}


