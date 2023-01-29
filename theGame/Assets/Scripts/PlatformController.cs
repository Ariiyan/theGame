using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public static PlatformController Instance;
    Rigidbody2D rb;
    private Vector2 inputVector, moveVector;
    private float yVel;
    private BoxCollider2D col;
    private Vector3 groundCheckA, groundCheckB, cellingCheckA, cellingCheckB;



    public float gravity = 9.81f;
    public float jumpVel = 9.81f;
    public float climbVel = 9.81f;
    public float speed = 5f;
    public float Moving_Speed = 5f;
    public float groundCheckRadius = 0.1f;
   // public LayerMask groundLayers, enemyLayer;
    bool grounded, jumpPressed,  squishEnemy, extraJump, cellinged, climbing;
    public bool laddered, wasLaddered;
    // Edit Var
    public AudioSource Jump_Aud;
    public bool IsJump, jumping,IsLadder;
    Animator Anim;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        Anim= GetComponent<Animator>();
       // CalculateScales();
        Manager.lastCheckPoint = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
      //  CalculateMovement();
      //  print("Laddered =" + laddered+IsJump+jumping);
        rb.velocity = inputVector;
        if (IsJump)
        {
            Jump();
        }
    }
    public void Jump()
    {
        Jump_Aud.PlayDelayed(0.05f);
        rb.velocity = new Vector2(rb.velocity.x, transform.up.y * speed);
            IsJump = false;

    }


    void GetInput()
    {
        float X = Input.GetAxisRaw("Horizontal");//storing in Variable to check weather it positive or negative 
        float Y = Input.GetAxisRaw("Vertical");//storing in Variable to check for Ladder  climbing
        inputVector = new Vector2(X*Moving_Speed, rb.velocity.y);
        if (X < 0)//if less then 0 means negative, so character is moving -x axis
        {
            this.transform.localRotation = Quaternion.Euler(0, 180, 0);//this is use for angles 
            Anim.SetBool("IsIdle", false);
            Anim.SetBool("IsRun", true);
        }
        else if (X > 0)//if greater then 0 means positive, so character is moving +x axis
        {
            this.transform.localRotation = Quaternion.Euler(0, 0, 0);//this is use for angles 
            Anim.SetBool("IsIdle", false);
            Anim.SetBool("IsRun", true);
        }
        else
        {
            Anim.SetBool("IsIdle", true);
            Anim.SetBool("IsRun", false);

        }
        //jumpPressed = Input.GetButtonDown("Jump");
        if (Input.GetButton("Jump") && !jumping)
        {
            IsJump = true;
            jumping = true;
        }
        if((Y>0||Y<0)&&IsLadder)
        {
            //physics law denied

            Physics_Acess(RigidbodyType2D.Kinematic);
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.01f, this.transform.position.z);
        }
    }
   
    public void Physics_Acess(RigidbodyType2D Rbd)
    {
        rb.bodyType=  Rbd;
    }


    //void CalculateMovement()
    //{
    //    if (!Manager.gamePaused)
    //    {
    //       // grounded = CheckCollision(groundCheckA, groundCheckB, groundLayers);
    //        //cellinged = CheckCollision(cellingCheckA, cellingCheckB, groundLayers);



    //        if (jumpPressed)
    //        {
    //            jumpPressed = false;
    //            if (grounded)
    //            {
    //                jumping = true;
    //                yVel = jumpVel;
    //            }
    //        }

    //        if (extraJump)
    //        {
    //            extraJump = false;
    //            jumping = true;
    //            yVel = jumpVel;
    //        }

    //        if (!grounded && yVel < 0f)
    //        {
    //           // squishEnemy = CheckCollision(groundCheckA, groundCheckB, enemyLayer);
    //            if (squishEnemy)
    //            {
    //                extraJump = true;
    //                jumping = true;
    //                yVel = jumpVel * 0.5f;
    //            }
    //        }

    //        if (grounded && yVel <= 0f || cellinged && yVel > 0f)
    //        {

    //            yVel = 0f;
    //            jumping = false;

    //        }
    //        else
    //        {
    //            yVel -= gravity * Time.deltaTime;
    //        }


    //        if (laddered && !wasLaddered)
    //        {
    //            if (inputVector.y != 0f)
    //            {
    //                climbing = true;
    //                wasLaddered = true;
    //            }
    //        }

    //        if (wasLaddered && !laddered)
    //        {
    //            climbing = false;
    //            wasLaddered = false;
    //        }


    //        if (climbing)
    //        {
    //            yVel = climbVel * inputVector.y;
    //        }



    //        moveVector.y = yVel;
    //        moveVector.x = inputVector.x * speed;
    //    }
    //}




    //bool CheckCollision(Vector3 a, Vector3 b, LayerMask l)
    //{
    //    Collider2D colA = Physics2D.OverlapCircle(transform.position - a, groundCheckRadius, l);
    //    Collider2D colB = Physics2D.OverlapCircle(transform.position - b, groundCheckRadius, l);




    //    if (colA)
    //    {
    //        //if (l == enemyLayer && yVel < 0f)
    //        //{
    //        //    colA.gameObject.GetComponent<EnemyHealthSystem>().ReceivedHit(1);
    //        //}
    //        //return true;

    //    }
    //    else if (colB)
    //    {
    //        //if (l == enemyLayer && yVel < 0f)
    //        //{
    //        //    colB.gameObject.GetComponent<EnemyHealthSystem>().ReceivedHit(1);
    //        //}
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }

    //}



    //void CalculateScales()
    //{
    //    groundCheckA = -col.offset - new Vector2(col.size.x / 2f - (groundCheckRadius * 1.2f), -col.size.y / 2.1f);
    //    groundCheckB = -col.offset - new Vector2(-col.size.x / 2f + (groundCheckRadius * 1.2f), -col.size.y / 2.1f);

    //    cellingCheckA = -col.offset - new Vector2(col.size.x / 2f - (groundCheckRadius * 1.2f), col.size.y / 2.1f);
    //    cellingCheckB = -col.offset - new Vector2(-col.size.x / 2f + (groundCheckRadius * 1.2f), col.size.y / 2.1f);
    //}


   
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(transform.position - groundCheckA, groundCheckRadius);
    //    Gizmos.DrawWireSphere(transform.position - groundCheckB, groundCheckRadius);
    //}


}
