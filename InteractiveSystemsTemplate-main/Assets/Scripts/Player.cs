using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject axePrefab;
    public GameObject bucketPrefab;
    public GameObject pickaxePrefab;
    public GameObject shovelPrefab;
    public Transform toolParent;
    public float cooldown;
    private bool onCooldown;
    // Start is called before the first frame update
    void Start()
    {
        onCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {   if(onCooldown){
            cooldown -= Time.deltaTime;
            if(cooldown<=0){
                onCooldown = false;
                cooldown = 5;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if(!onCooldown){
            onCooldown = true;
            switch (other.tag) 
            {
                case "AxeButton":
                    Destroy(toolParent.GetChild(0).gameObject); 
                    Instantiate(axePrefab, toolParent);
    
                break;

                case "PickaxeButton":
                    Destroy(toolParent.GetChild(0).gameObject); 
                    Instantiate(pickaxePrefab, toolParent);
                break;

                case "ShovelButton":
                    Destroy(toolParent.GetChild(0).gameObject); 
                    Instantiate(shovelPrefab, toolParent);
                break;

                case "BucketButton":
                    Destroy(toolParent.GetChild(0).gameObject); 
                    Instantiate(bucketPrefab, toolParent);
                break;
                default:
                    onCooldown = false;
                break;
            }
            
        }
    }
 
}
