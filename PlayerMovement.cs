using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 1f;
    bool jump = false;
    
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    //public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    // Start is called before the first frame update
    public Vector2 feetPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
     
     void FixedUpdate()
    {
        //Move our character 
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        moveInput = Input.GetAxisRaw("Horizontal");
        //rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    
    // Update is called once per frame
     void Update()
    {
        
        Animator animator = GetComponent<Animator>();
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        isGrounded = Physics2D.OverlapCircle(feetPos, checkRadius, whatIsGround);
        
        /*if(moveInput > 0){
          transform.eulerAngles = new Vector3(0, 0, 0);
        } else if(moveInput < 0){
          transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)){
          isJumping = true;
          jumpTimeCounter = jumpTime;
          rb.velocity = Vector2.up * jumpForce;
       
        }

        if(Input.GetKeyDown(KeyCode.Space) && isJumping == true){
            if(jumpTimeCounter > 0){
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;
            } else { 
                isJumping = false;
        }
    }*/
   
    void OnLanding ()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("IsJumping", false);
    }
}}

