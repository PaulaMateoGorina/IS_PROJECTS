using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmissionPlace : MonoBehaviour
{

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered");
            Player playerScript = other.gameObject.GetComponent<Player>();
            if (playerScript != null && playerScript.holdingMaterial())
            {
                SubmissionManager.Instance.updateMaterialsNeeded(other.transform.GetChild(0).gameObject.tag);
                playerScript.freeHand();
                Debug.Log("Submitted");
            }
        }
    }
}
