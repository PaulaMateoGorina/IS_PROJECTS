using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public int hitsToDestroy;
    public string toolTag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnCollisionEnter(Collision collision){
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Player") && collision.transform.GetChild(0).gameObject.CompareTag(toolTag)){
            hitsToDestroy--;
            Debug.Log("Hit");
            if(hitsToDestroy <= 0){
                Destroy(gameObject);
                Debug.Log("Destroyed");
            }
        }//Debug.Log("Collision detected");
    }
}
