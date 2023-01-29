using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_WDetector : MonoBehaviour

{
    EnemyMovement Env_Movement;
    
    private void Start()
    {
        Env_Movement = this.transform.GetComponentInParent<EnemyMovement>();// it will get the parent    
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag == "Wall")
        {
            Env_Movement.turning = true;
        }
     
    }
}
