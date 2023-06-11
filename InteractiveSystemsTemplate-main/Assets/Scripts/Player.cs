using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script controls the behaviour of the players.
*/

public class Player : MonoBehaviour
{
    public GameObject handPrefab;
    public int numPlayer;
    
    public float cooldown;
    private bool isHoldingMaterial;
    private bool isHoldingTool;
    private bool onCooldown;
 


    // Start is called before the first frame update
    void Start()
    {
        onCooldown = false;
        isHoldingMaterial = false;
        isHoldingTool = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if(onCooldown){
            cooldown -= Time.deltaTime;
            if(cooldown<=0){
                onCooldown = false;
                cooldown = 3;
            }
        }
    }

    // Function that given a tool, material or hand prefab, changes the object that the player is holding to the given one. 
    public void changeHeldObject(GameObject prefab, bool isTool, bool isMaterial){
        //Set the variables accordingly wether it is holding a tool or a material
        isHoldingTool = isTool;
        isHoldingMaterial = isMaterial;

        Destroy(gameObject.transform.GetChild(0).gameObject); 
        Instantiate(prefab, gameObject.transform);
    }

    // Given a prefab of a tool, if there is no cooldown and it is not holding a material, we change the tool that the player is carrying.
    // This cooldown refers to the penalisation of changing tools too often.  
    public void changeTool(GameObject toolPrefab)
    {
        if (!onCooldown && !isHoldingMaterial)
        {
            onCooldown = true;
            changeHeldObject(toolPrefab, true, false);
        }
    }

    // Returns whether the user is holding a material or not
    public bool holdingMaterial()
    {
        return isHoldingMaterial;
    }

    // Frees the hand of the player
    public void freeHand()
    {
        changeHeldObject(handPrefab, false, false);
    }

    // Returns wheter the player is holding a tool or not. 
    public bool holdingTool(){

        return isHoldingTool;
    }
   
}

