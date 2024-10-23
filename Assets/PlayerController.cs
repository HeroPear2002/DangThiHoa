using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Horizontal Movement Setting")]
    [SerializeField] private float walkSpeed = 1;
    // trục
    [Header("Ground CHeck Settings")]
    [SerializeField] private float JumpForce = 45f;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckY = 0.2f;
    [SerializeField] private float groundCheckX = 0.5f;
    [SerializeField] private LayerMask whatIsGround;
     
    public Rigidbody2D rb;
    private BoxCollider2D coll;
    // tốc độ của nhân vật khi đo bộ
    public float xAxis, y;
    public Animator anim;

    public static PlayerController Instance;
    [System.NonSerialized]
    public StateMachine stateMachine;

    // singleton pattern 
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        stateMachine = new StateMachine(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        stateMachine.Initialize(stateMachine.idleState);

    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();

        GetInputs();
        Move();
        Jump();
        Flip();
        //if (Input.GetButtonDown("JumpForce"))
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        //}    
    }
    // hàm để đi chuyển theo trục ngang và đưa vào update để cập nhật chúng
    void GetInputs()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
    }

    // doi chieu Player
    void Flip()
    {
        if (xAxis < 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if (xAxis > 0)
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }
    // hàm di chuyển 
    private void Move()
    {
        rb.velocity = new Vector2(walkSpeed * xAxis, rb.velocity.y);
       // anim.SetBool("Walking", rb.velocity.x != 0 && Grounded());
    }
    // kiem tra mat dat
    //public bool Grounded()
    //{
    //    if (Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckY, whatIsGround)
    //        || Physics2D.Raycast(groundCheckPoint.position + new Vector3(groundCheckX, 0, 0), Vector2.down, groundCheckY, whatIsGround)
    //        || Physics2D.Raycast(groundCheckPoint.position + new Vector3(-groundCheckX, 0, 0), Vector2.down, groundCheckY, whatIsGround))
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
    void Jump()
    {
        if (Input.GetButtonUp("JumpForce") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        if (Input.GetButtonDown("JumpForce") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce);
        }
        //anim.SetBool("Jumping", !Grounded());
    }
    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .05f, whatIsGround);
    }
}
 