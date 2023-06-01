using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(player1WantsHelp || player1WantsHelp)
            helpSign.SetActive(true);
        else
            helpSign.SetActive(false); 
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
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
