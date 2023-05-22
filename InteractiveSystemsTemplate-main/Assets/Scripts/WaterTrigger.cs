using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{   
    public string toolTag;
    public GameObject waterBucketPrefab;

    private float cooldown;
    private bool onCooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other){
        Debug.Log("entered water");
        if (SubmissionManager.Instance.isMaterialNeeded(gameObject.tag))
        {
            if (!onCooldown && other.gameObject.CompareTag("Player") && other.transform.GetChild(0).gameObject.CompareTag(toolTag))
            {
                Player playerScript = other.gameObject.GetComponent<Player>();
                if (playerScript != null)
                {
                    playerScript.changeHeldObject(waterBucketPrefab, false);
                }
            }
        }
        else
        {
            //TODO: display
        }
     }
}
