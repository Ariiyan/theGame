using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Detector : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)//when collider remain in trigger with another collider
    {
        if(collision.tag=="Ground")
            PlatformController.Instance.jumping = false;//player in air

        if(collision.tag=="Ladder")
            PlatformController.Instance.IsLadder = true;//colliding with ladder

    }
    private void OnTriggerExit2D(Collider2D collision)//when trigger exit like trigger is not colliding with any one
    {
        PlatformController.Instance.IsLadder = false;//colliding with ladder ends
        PlatformController.Instance.Physics_Acess(RigidbodyType2D.Dynamic);//Again apply physics

    }

    private void OnTriggerEnter2D(Collider2D collision)//return only one collision, like if object collide, just give info that it collide with some other collider, doesn't matter remain in collision or not
    {
        if(collision.tag=="Enemy" )
        {
            if (!PlatformController.Instance.IsJump)//Player is jumping
            {
                collision.GetComponent<EnemyHealthSystem>().ReceivedHit(1);
                //Player should jump
                PlatformController.Instance.Jump();
            }
           
        }
    }
}
