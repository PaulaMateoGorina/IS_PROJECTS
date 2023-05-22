using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject handPrefab;
    
    public float cooldown;
    private bool onCooldown;
    private bool hand_free;

    // Start is called before the first frame update
    void Start()
    {
        onCooldown = false;
        hand_free = true;
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
        hand_free = is_tool;
        Destroy(gameObject.transform.GetChild(0).gameObject); 
        Instantiate(prefab, gameObject.transform);
    }

    public void changeTool(GameObject toolPrefab)
    {
        if (!onCooldown && hand_free)
        {
            onCooldown = true;
            changeHeldObject(toolPrefab, true);
        }
    }

    public bool holdingMaterial()
    {
        return !hand_free;
    }

    public void freeHand()
    {
        changeHeldObject(handPrefab, true);
    }
}

