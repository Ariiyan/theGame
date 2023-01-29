using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public bool initalDirectionRight = false; 
    private float directioMulti = 1f;
    public float speed = 1; 
    private Rigidbody2D rb; 
    private BoxCollider2D col; 
    private Vector3 groundCheckOffsetA, groundCheckOffsetB, frontPlayerCol, backPlayerCol; 
    public float groundCheckRadius = 0.1f; 
  //  public LayerMask groundlayers, playerLayer; 
    public bool turning = false,Allow_Turning;
    private bool turningWall = false;
    public bool HitPlayer;
    private SpriteRenderer sp;


    // Start is called before the first frame update
    void Start()
    {
        HitPlayer = false;
        Allow_Turning = true;

        rb = GetComponent<Rigidbody2D>();
      //  col = GetComponent<BoxCollider2D>();
        sp = GetComponent<SpriteRenderer>();
        //CheckScales();

        if (initalDirectionRight)
        {

            directioMulti = 1;
            sp.flipX = !sp.flipX;

        }
        else
        {
            directioMulti = -1;

        }

    }

        // Update is called once per frame
        void Update()
    {
        CalculateMovement();
        rb.velocity = new Vector3(speed * directioMulti, rb.velocity.y, 0);

    }



    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.white;
    //    Gizmos.DrawWireSphere(transform.position - groundCheckOffsetA, groundCheckRadius);

    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position - groundCheckOffsetB, groundCheckRadius);

    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireSphere(transform.position - frontPlayerCol, groundCheckRadius);

    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position - backPlayerCol, groundCheckRadius);


    //}

    

    //void CheckScales()
    //{
    //    groundCheckOffsetA = -col.offset - new Vector2(col.size.x / 2f - (groundCheckRadius * 1.2f), -col.size.y / 2f);
    //    groundCheckOffsetB = -col.offset - new Vector2(-col.size.x / 2f + (groundCheckRadius * 1.2f), -col.size.y / 2f);

    //    frontPlayerCol = -col.offset - new Vector2(col.size.x / 2f, 0);
    //    backPlayerCol = -col.offset - new Vector2(-col.size.x / 2f, 0);
    //}

    void CalculateMovement()
    {
        //bool platformed = CheckEndOfPlatform(groundCheckOffsetA, groundCheckOffsetB, groundlayers);
        //bool hitWall = CheckPlayerOrWallColl(frontPlayerCol, backPlayerCol, groundlayers);
        //bool hitPlayer = CheckPlayerOrWallColl(frontPlayerCol, backPlayerCol, playerLayer);





        //if (!platformed && !turning || hitWall && !turningWall || hitPlayer && !turningWall)
        //{
        //    directioMulti *= -1;
        //    turning = true;
        //    turningWall = true;
        //    sp.flipX = !sp.flipX;
        //}

        //if(platformed && turning)
        //{
        //    turning = false;
        //}
        //if (!hitWall && turningWall && !hitPlayer)
        //{
        //    turningWall = false;
        //}

        if (HitPlayer)
        {
            HitPlayer = false;
            GameObject.FindGameObjectWithTag("Player").transform.position = Manager.lastCheckPoint;
            Manager.Add_Lives(-1);

        }
        if (turning&& Allow_Turning)// Allow Turning basically when collider remains in collision with wall it will conitnously fliping the rotation
        {
            directioMulti *= -1;// if we multiply -1 with -1 its +1 and again multiply 1 with -1 its -1, toggle the sign
            sp.flipX = !sp.flipX;
            Allow_Turning=turning = false;
            Invoke("Allow_Turning_Func", 1f);//this function will call after 1 second, its same like IEnumerator 
        }
    }
    void Allow_Turning_Func()
    {
        Allow_Turning = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)//two colliders collide while is trigger off, so it get info of collision's object
    {
        if (collision.gameObject.tag == "Player")
        {
            HitPlayer = true;

        }
    }
    //bool CheckEndOfPlatform(Vector3 a, Vector3 b, LayerMask l)
    //{
    //    if(Physics2D.OverlapCircle(transform.position - a, groundCheckRadius, l) && 
    //Physics2D.OverlapCircle(transform.position - b, groundCheckRadius, l))
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }

    //}



    //bool CheckPlayerOrWallColl(Vector3 a, Vector3 b, LayerMask l)
    //{

    //    if(Physics2D.OverlapCircle(transform.position - a, groundCheckRadius, l) ||
    //Physics2D.OverlapCircle(transform.position - b, groundCheckRadius, l))
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }

    //}



}
