using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject handPrefab;
    public int num_player;
    
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
                cooldown = 5;
            }
        }
    }

    public void changeHeldObject(GameObject prefab, bool is_tool){
        isHoldingTool = is_tool;
        isHoldingMaterial = !is_tool;
        Destroy(gameObject.transform.GetChild(0).gameObject); 
        Instantiate(prefab, gameObject.transform);
    }

    public void changeTool(GameObject toolPrefab)
    {
        if (!onCooldown && !isHoldingMaterial)
        {
            onCooldown = true;
            changeHeldObject(toolPrefab, true);
        }
    }

    public bool holdingMaterial()
    {
        return isHoldingMaterial;
    }

    public void freeHand()
    {
        changeHeldObject(handPrefab, false);
    }

    public bool holdingTool(){

        return isHoldingTool;
    }
   
}

