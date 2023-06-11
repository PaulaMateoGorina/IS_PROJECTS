using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
This script controlls the behaviour of the play again button used in the winning and game over stage. 
*/
public class PlayAgainButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //If the object interacting with the button is tha player, we load the initial screen again. 
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Scene");
        }
        
    }
}
