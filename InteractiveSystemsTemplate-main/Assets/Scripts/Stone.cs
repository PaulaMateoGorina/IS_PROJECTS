using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Player") && collision.transform.GetChild(0).GetChild(0).gameObject.CompareTag("Pickaxe")){
            count--;
            Debug.Log("Rock Hit");
            if(count <= 0){
                Destroy(gameObject);
                Debug.Log("Rock destroyed");
            }
        }//Debug.Log("Collision detected");
    }
}
