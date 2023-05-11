using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject axePrefab;
    public GameObject bucketPrefab;
    public GameObject pickaxePrefab;
    public GameObject shovelPrefab;
    public Transform player_transform;
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
                    Destroy(player_transform.GetChild(0).gameObject); 
                    Instantiate(axePrefab, player_transform);
                break;

                case "PickaxeButton":
                    Destroy(player_transform.GetChild(0).gameObject); 
                    Instantiate(pickaxePrefab, player_transform);
                break;

                case "ShovelButton":
                    Destroy(player_transform.GetChild(0).gameObject); 
                    Instantiate(shovelPrefab, player_transform);
                break;

                case "BucketButton":
                    Destroy(player_transform.GetChild(0).gameObject); 
                    Instantiate(bucketPrefab, player_transform);
                break;
                default:
                    onCooldown = false;
                break;
            }
            
        }
    }
 
}
