using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public int hitsToDestroy;
    public string toolTag;
    public GameObject collectedMaterialPrefab;

    public float cooldown;
    private bool onCooldown;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      if(onCooldown){
            cooldown -= Time.deltaTime;
            if(cooldown<=0){
                onCooldown = false;
                cooldown = 0.5;
            }
        }
    }

   /* private void OnCollisionEnter(Collision collision){
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Player") && collision.transform.GetChild(0).gameObject.CompareTag(toolTag)){
            hitsToDestroy--;
            Debug.Log("Hit");
            if(hitsToDestroy <= 0){
                Destroy(gameObject);
                Debug.Log("Destroyed");
                
            }
        }//Debug.Log("Collision detected");
    }*/

    private void OnCollisionEnter(Collision collision){
    Debug.Log("Collision");
    if (!onCooldown && collision.gameObject.CompareTag("Player") && collision.transform.GetChild(0).gameObject.CompareTag(toolTag)){
        hitsToDestroy--;
        Debug.Log("Hit");
        if(hitsToDestroy <= 0){
          
            Player playerScript = collision.gameObject.GetComponent<Player>();
            if (playerScript != null) {
                // Call SomeFunction in the Player script
                playerScript.changeHeldObject(collectedMaterialPrefab, false);
            }
            Destroy(gameObject);
            Debug.Log("Destroyed");    
        }
    }
}

}
