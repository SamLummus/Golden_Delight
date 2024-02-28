using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    //public PlatformManager platformManagerScript;

    private bool collected;

    private void Update()
    {
        collected = false;
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin") && collected == false)
        {
            ScoreCounter.coinAmount += 1;
            collected = true;
            Destroy(collision.gameObject);
            //platformManagerScript.NewPlatform();//
        }
    }
}
