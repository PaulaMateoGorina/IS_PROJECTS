using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject toolPrefab;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Player playerScript = other.gameObject.GetComponent<Player>();
            if (playerScript != null)
                playerScript.changeTool(toolPrefab);
        }
        
    }
}
