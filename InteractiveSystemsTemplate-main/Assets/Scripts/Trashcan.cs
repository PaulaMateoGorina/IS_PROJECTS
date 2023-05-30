using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Player playerScript = other.gameObject.GetComponent<Player>();
            if (playerScript != null)
                playerScript.freeHand();
        }
        
    }
}
