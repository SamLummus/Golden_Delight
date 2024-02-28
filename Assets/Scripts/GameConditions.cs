using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConditions : MonoBehaviour
{
    public bool pureHeart = true;
    public bool hasSecretSpell = true;
    public string rareItem = "Relic Stone";
    public int gameLevel = 1;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OpenTreasureChamber("Ax", gameLevel);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            OpenTreasureChamber("Sword", gameLevel);
        }
    }

    public void OpenTreasureChamber(string weapon, int gameLevel)
    {
        if (rareItem == "Ax")
        {
            if (pureHeart = true && rareItem == "Relic Stone")
            {
                Debug.Log("You have the Ax, a pure heart and the relic");
                gameLevel++;
                PassOn(gameLevel);
            }
        } 
        
        else if (rareItem == "Sword")
        {
            Debug.Log("You don't have the magical ax, instead you have a bum ass sword");
        }
            
    }

    public void PassOn (int gameLevel)
        {
            if (gameLevel >= 2 && hasSecretSpell == true)
            {
                Debug.Log("Pass on to the next level with the secret spell, you have entered the chamber");
            }
        }

}
