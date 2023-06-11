using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class is in charge of the behaviour of the trashcan
*/

public class Trashcan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // If the object interacting with it is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // It frees the player's hand
            Player playerScript = other.gameObject.GetComponent<Player>();
            if (playerScript != null)
                playerScript.freeHand();
        }
        
    }
}
