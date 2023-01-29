using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manager : MonoBehaviour
{

    public static Manager instance;
    public static int coins;
    public enum DoorKeyColours { Red, Blue, Yellow };
    public static bool redKey, blueKey, yellowKey;
    public static Vector3 lastCheckPoint;
    public static bool gamePaused;
    public static int Player_Lives = 3;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static void AddCoins(int coinValue)
    {
        coins += coinValue;
    }
    public static void Add_Lives(int Lives)
    {
        Player_Lives += Lives;
        
    }

    public static void KeyPickup(DoorKeyColours keyColour )
    {
        switch (keyColour)
        {
            case DoorKeyColours.Red:
                redKey = true;
                break;
            case DoorKeyColours.Blue:
                blueKey = true;
                break;
            case DoorKeyColours.Yellow:
                yellowKey = true;
                break;
            
        }
    }

    public static void UpdateCheckPoints(GameObject flag)
    {
        lastCheckPoint = flag.transform.position;
        CheckPoint[] allCheckPoints = FindObjectsOfType<CheckPoint>();
        foreach (CheckPoint cp in allCheckPoints)

        {
            if (cp != flag.GetComponent<CheckPoint>())
            {

                cp.LowerFlag();
            }
        }

    }
}