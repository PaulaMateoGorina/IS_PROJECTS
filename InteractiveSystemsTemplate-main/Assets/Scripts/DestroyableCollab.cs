using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableCollab : MonoBehaviour
{
    public int hitsToDestroy;
    public string toolTag;
    public GameObject collectedMaterialPrefab;


    private int player1HitsRemaining;
    private int player2HitsRemaining;
    private float turnCoolDown;
    private float lastTurnTime;

    private bool arePlayersHitting;
    private bool firstPlayer;
    private bool nextPlayer;
    private int curHits;

    // Start is called before the first frame update
    void Start()
    {


        player1HitsRemaining = 3;
        player2HitsRemaining = 3; 

        //isplayerTurn1 =  true;
        //isplayerTurn1 =  true;
        arePlayersHitting = false;
        curHits = 0;
        turnCoolDown = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if(collision.gameObject.CompareTag("Player") && collision.transform.GetChild(0).gameObject.CompareTag(toolTag))
    //     {   
            
    //         //First of all we need to check the player that is colliding
    //         Player playerScript = collision.gameObject.GetComponent<Player>();
    //         int num_player = playerScript.num_player;

    //         //if the one colliding is player 1, we need to check wether it is its turn and if the time between the last time player2 hit the rock is less than the turnCooldown.
    //         if(num_player==1 && isplayerTurn1 && Time.time - lastTurnTime > turnCooldown  )
    //         {
    //             player1HitsRemaining--; 
    //             lastTurnTime = Time.time; 
    //             //If the number of hits remaining is less or equal than cero, we get the material and destroy the rock
    //             if (player1HitsRemaining <= 0)
    //             {
    //                 playerScript.changeHeldObject(collectedMaterialPrefab, false);
    //                 Destroy(gameObject);
    //                 Debug.Log("Destroyed");
    //             }
    //             else
    //             {
    //                 isplayerTurn1 = false;
    //             }

    //             //If both players turns are done, we set them to true again 
    //             if(!isplayerTurn1 && !isplayerTurn2)
    //             {
    //                 isplayerTurn1 = true;
    //                 isplayerTurn2 = true;

    //             }

    //         }
    //         //We do the same with player 2
    //         if(num_player==2 && isplayerTurn2 && Time.time - lastTurnTime > turnCooldown  )
    //         {
    //             player2HitsRemaining--; 
    //             lastTurnTime = Time.time; 
    //             if (player2HitsRemaining <= 0)
    //             {
    //                 playerScript.changeHeldObject(collectedMaterialPrefab, false);
    //                 Destroy(gameObject);
    //                 Debug.Log("Destroyed");
    //             }
    //             else
    //             {
    //                 isplayerTurn2 = false;
    //             }

    //             //If both players turns are done, we set them to true again 
    //             if(!isplayerTurn1 && !isplayerTurn2)
    //             {
    //                 isplayerTurn1 = true;
    //                 isplayerTurn2 = true;

    //             }
    //         }
    //         else{
                
    //             player1HitsRemaining = 3;
    //             player2HitsRemaining = 3;
    //             lastTurnTime = Time.time;

    //             //Set the turns to 1
    //             isplayerTurn1 = true;
    //             isplayerTurn2 = true;

    //         }
    //     }
    // }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.transform.GetChild(0).gameObject.CompareTag(toolTag))
        {   
            Player playerScript = collision.gameObject.GetComponent<Player>();
            int num_player = playerScript.num_player;

            if(!arePlayersHitting && Time.time - lastTurnTime > turnCoolDown)
            {
                arePlayersHitting = true;
                firstPlayer = (num_player % 2) == 1;
                nextPlayer = !firstPlayer;
                lastTurnTime = Time.time;
            }
            else if ( (num_player % 2 == 0) == nextPlayer && Time.time - lastTurnTime > turnCoolDown){
                if(firstPlayer != nextPlayer)
                {
                    curHits ++;
                    arePlayersHitting = false;
                }
                if(curHits == hitsToDestroy)
                {
                    playerScript.changeHeldObject(collectedMaterialPrefab, false);
                    Destroy(gameObject);
                    Debug.Log("Destroyed");
                }

            }
            else{
                curHits = 0;
                arePlayersHitting = false;
            }
        }
    }
    
}





