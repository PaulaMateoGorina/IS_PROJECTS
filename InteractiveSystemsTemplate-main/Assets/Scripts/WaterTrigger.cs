using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{   
    public string toolTag;
    public GameObject collectedMaterialPrefab;

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

     private void OnTriggerEnter(Collider collision){
        Debug.Log("Collision");
        if (Submission.Instance.isMaterialNeeded(gameObject.tag))
        {
            if (!onCooldown && collision.gameObject.CompareTag("Player") && collision.transform.GetChild(0).gameObject.CompareTag(toolTag))
            {
                Player playerScript = collision.gameObject.GetComponent<Player>();
                if (playerScript != null)
                {
                    playerScript.changeHeldObject(collectedMaterialPrefab, false);
                }
            }
        }
        else
        {
            //TODO: display
        }
    }
}
