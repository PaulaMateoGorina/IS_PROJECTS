using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("entered water");
        if(other.gameObject.CompareTag("Player"))
        {
            Player playerScript = other.gameObject.GetComponent<Player>();
            if (SubmissionManager.Instance.isMaterialNeeded(gameObject.tag))
            {
                if (!onCooldown && other.transform.GetChild(0).gameObject.CompareTag(toolTag))
                {
                    if (playerScript != null)
                    {
                        playerScript.changeHeldObject(waterBucketPrefab, false, true);
                        SoundManager.Instance.PlayWaterInBucket();
                    }
                }
            }
            else if (playerScript.holdingTool())
            {
                Debug.Log("Incorrect Material!!");
                errorText.SetActive(true);
                StartCoroutine(hideError(5.0f));
                SoundManager.Instance.PlayIncorrect();
            }
        }
    }
    private IEnumerator hideError(float delay)
    {
        yield return new WaitForSeconds(delay);
        errorText.SetActive(false);
    }
}
