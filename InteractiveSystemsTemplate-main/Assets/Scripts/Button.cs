using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script controls the behaviour of the buttons that are used to change the tools
*/

public class Button : MonoBehaviour
{
    public GameObject toolPrefab;

    private void OnTriggerEnter(Collider other)
    {
        //We check if the object that collides has the appropiate tag
        if (other.gameObject.CompareTag("Player"))
        {
            //Then, we get the script and call the function to change tool
            Player playerScript = other.gameObject.GetComponent<Player>();
            if (playerScript != null)
                playerScript.changeTool(toolPrefab);
        }
        
    }
}
