using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickups : MonoBehaviour
{

    public Manager.DoorKeyColours keyColour;
    public AudioSource Key_PickUp;
   public BoxCollider2D Door_Collider;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        switch (keyColour)
        {
            case Manager.DoorKeyColours.Red:
                sr.color = Color.red;
                break;
            case Manager.DoorKeyColours.Blue:
                sr.color = Color.blue;
                break;
            case Manager.DoorKeyColours.Yellow:
                sr.color = Color.yellow;
                break;

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Key_PickUp.Play();
            Manager.KeyPickup(keyColour);
            Destroy(gameObject);
            Door_Collider.isTrigger = true;
            //Destroy(Door);
        }
    }




}
