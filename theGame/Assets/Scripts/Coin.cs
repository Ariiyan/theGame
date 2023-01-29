using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 5;
    public AudioSource Coin_Audio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Coin_Audio.Play();
            Manager.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }


}
