using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableCollab : MonoBehaviour
{
    public int hitsToDestroy;
    public string toolTag;
    public float timeBetweenTurns;
    public int curHits;

    private float lastTurnTime;
    private bool arePlayersHitting;
    private bool firstPlayer;
    private bool nextPlayer;
    private float cooldown;
    

    // Start is called before the first frame update
    void Start()
    {
        arePlayersHitting = false;
        curHits = 0;
        lastTurnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenTurns -= Time.deltaTime;
        if( timeBetweenTurns <=0 )
        {
            timeBetweenTurns = 20;
            curHits = 0;
            arePlayersHitting = false;
            lastTurnTime = Time.time;
        }
        if(cooldown > 0 )
        {
            cooldown -= Time.deltaTime;
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit1");
        if(collision.gameObject.CompareTag("Player") && collision.transform.GetChild(0).gameObject.CompareTag(toolTag))
        {   
            Debug.Log("hit2");
            Player playerScript = collision.gameObject.GetComponent<Player>();
            int numPlayer = playerScript.numPlayer;

            // If players have not started hitting, or the rock has reset
            if(!arePlayersHitting)
            {
                arePlayersHitting = true;
                SoundManager.Instance.PlayStoneMining();
                // Take the first player -> bools are easy to switch from one value to another
                firstPlayer = (numPlayer % 2) == 0;
                nextPlayer = !firstPlayer;

                // Maximum time a player can take to hit the rock after the other one has done it
                timeBetweenTurns = 20;

                // Cooldown so we don't collision forever
                cooldown = 1.0f;
            }
            // If the player that is hitting it matches the next in line, and there is no cooldown
            else if ( (numPlayer % 2 == 0) == nextPlayer && cooldown <= 0)
            {
                // If the player other than the one who started hit it, it means both players have already hit the rock, so we add one hit
                if(firstPlayer != nextPlayer)
                {
                    SoundManager.Instance.PlayStoneMining();
                    curHits ++;
                }
                // If the hits are the needed ones to destroy it
                if(curHits == hitsToDestroy)
                {
                    Destroy(gameObject);
                    Debug.Log("Destroyed");
                    // Advance to the next phase of the tutorial
                    TutorialManager.Instance.next();
                }

                // Change the next player accordingly
                nextPlayer = !nextPlayer;
        
                timeBetweenTurns = 20;
                cooldown = 1.0f;
            }
        }
    }
    
}









    // private void OnCollisionEnter(Collision collision)
    // {
    //     if(collision.gameObject.CompareTag("Player") && collision.transform.GetChild(0).gameObject.CompareTag(toolTag))
    //     {   
            
    //         //First of all we need to check the player that is colliding
    //         Player playerScript = collision.gameObject.GetComponent<Player>();
    //         int numPlayer = playerScript.numPlayer;

    //         //if the one colliding is player 1, we need to check wether it is its turn and if the time between the last time player2 hit the rock is less than the turnCooldown.
    //         if(numPlayer==1 && isplayerTurn1 && Time.time - lastTurnTime > turnCooldown  )
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
    //         if(numPlayer==2 && isplayerTurn2 && Time.time - lastTurnTime > turnCooldown  )
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





