using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
This class controls the behaviour of the submission place
*/

public class SubmissionPlace : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //If the one colliding is the player
        if (other.gameObject.CompareTag("Player"))
        {
           //If it is holding a material, we update the list of materials needed and free the hand. 
            Player playerScript = other.gameObject.GetComponent<Player>();
            if (playerScript != null && playerScript.holdingMaterial())
            {
                SubmissionManager.Instance.updateMaterialsNeeded(other.transform.GetChild(0).gameObject.tag);
                playerScript.freeHand();
            }
        }
    }
}
