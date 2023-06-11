using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class manages the help sign 
*/


public class Help : MonoBehaviour
{
    public GameObject helpSign;
    private bool player1WantsHelp;
    private bool player2WantsHelp;
    
    // Start is called before the first frame update
    void Start()
    {
        helpSign.SetActive(false);
    }

    void Update()
    {
        // If any of the players wants help, we activate the sign
        if(player1WantsHelp || player2WantsHelp)
            helpSign.SetActive(true);
        else
            helpSign.SetActive(false); 
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if the object interacting is a player. If so, we check which one. 
        if (other.gameObject.CompareTag("Player"))
        {
            Player playerScript = other.gameObject.GetComponent<Player>();
            if (playerScript != null)
            {
                if(playerScript.numPlayer == 1)
                    player1WantsHelp = true;
                if (playerScript.numPlayer == 2)
                    player2WantsHelp = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // We disable the help when the players are no longer touching the sign.
        if (other.gameObject.CompareTag("Player"))
        {
            Player playerScript = other.gameObject.GetComponent<Player>();
            if (playerScript != null)
            {
                if (playerScript.numPlayer == 1)
                    player1WantsHelp = false;
                if (playerScript.numPlayer == 2)
                    player2WantsHelp = false;
            }
        }
    }
}
