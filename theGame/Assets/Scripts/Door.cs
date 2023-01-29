using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Manager.DoorKeyColours keyColour;
    GameObject door;

    // Start is called before the first frame update
    void Start()
    {

        door = this.gameObject;//transform.Find("door").gameObject;
        SpriteRenderer sr = door.GetComponentInChildren<SpriteRenderer>();

        switch (keyColour)
        {
            case Manager.DoorKeyColours.Red:
                {
                    sr.color = Color.red;
                }
                break;
            case Manager.DoorKeyColours.Blue:
                {
                    sr.color = Color.blue;

                }
                break;
            case Manager.DoorKeyColours.Yellow:
                {
                    sr.color = Color.yellow;

                }
                break;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && door!=null)
        {
            switch (keyColour)
            {
                case Manager.DoorKeyColours.Red:
                    if (Manager.redKey) Destroy(door);
                    break;
                case Manager.DoorKeyColours.Blue:
                    if (Manager.blueKey) Destroy(door);
                    break;
                case Manager.DoorKeyColours.Yellow:
                    if (Manager.yellowKey) Destroy(door);
                    break;
            }
        }
    }

}
