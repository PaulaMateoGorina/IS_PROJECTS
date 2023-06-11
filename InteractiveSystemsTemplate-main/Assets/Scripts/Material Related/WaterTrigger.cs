using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Class responsible of controlling the behaviour of the water stage material.
*/
public class WaterTrigger : MonoBehaviour
{   
    public string toolTag;
    public GameObject waterBucketPrefab;

    private float cooldown;
    private bool onCooldown;
    public GameObject errorText;

    // Start is called before the first frame update
    void Start()
    {
        errorText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other){
       // If the one colliding is the player
        if(other.gameObject.CompareTag("Player"))
        {
            //We check wether we need or not the water
            Player playerScript = other.gameObject.GetComponent<Player>();
            if (SubmissionManager.Instance.isMaterialNeeded(gameObject.tag))
            {
                //We check that we are not in cooldown and that we are using the appropiate tool. this cooldown controls that the player 
                //is not constantly hitting. 
                if (!onCooldown && other.transform.GetChild(0).gameObject.CompareTag(toolTag))
                {
                    if (playerScript != null)
                    {
                        //Change the bucket for filled bucket.
                        playerScript.changeHeldObject(waterBucketPrefab, false, true);
                        SoundManager.Instance.PlayWaterInBucket();
                    }
                }
            }
            // if not, error message appears
            else if (playerScript.holdingTool())
            {
               
                errorText.SetActive(true);
                StartCoroutine(hideError(5.0f));
                SoundManager.Instance.PlayIncorrect();
            }
        }
    }

    // IEnumerator needed to hide the error message after some seconds.
    private IEnumerator hideError(float delay)
    {
        yield return new WaitForSeconds(delay);
        errorText.SetActive(false);
    }
}
