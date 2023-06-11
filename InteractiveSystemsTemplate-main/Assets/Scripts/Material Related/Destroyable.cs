using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
This class controls the behabiour of the stage materials that are destroyed when recollected (all except water)
*/

public class Destroyable : MonoBehaviour
{
    public int hitsToDestroy;
    public string toolTag;
    public GameObject collectedMaterialPrefab;

    private float cooldown;
    private bool onCooldown;

    public GameObject errorText;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0.5f;
        onCooldown = false;
        errorText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
      if(onCooldown){
        cooldown -= Time.deltaTime;
        if(cooldown <= 0.0f){
            onCooldown = false;
            cooldown = 0.5f;
        }
       }
    }

    private void OnCollisionEnter(Collision collision)
    {
      // If the one colliding is the player
        if(collision.gameObject.CompareTag("Player"))
        {
            Player playerScript = collision.gameObject.GetComponent<Player>();

            // If we need the material that the player is tryin to collect
            if (SubmissionManager.Instance.isMaterialNeeded(gameObject.tag))
            {
                //We need to check wether we are in cooldown and if the tool is the appropiate one.
                if (!onCooldown && collision.transform.GetChild(0).gameObject.CompareTag(toolTag))
                {

                    //If so, we need one hit less to destroy the object and we are in coolDown. This cooldown controls that the user is not constantly colliding. 
                    hitsToDestroy--;
                    onCooldown = true;
                    
                    // If the number of hits is sufficient
                    if (hitsToDestroy <= 0)
                    {
                        //The player obtains the collected material.
                        if (playerScript != null)
                            playerScript.changeHeldObject(collectedMaterialPrefab, false, true);
                        // The stage material is destroyed and we play the appropiate sound 
                        Destroy(gameObject);
                        SoundManager.Instance.PlayGetMaterial();
                    }
                    else
                    {
                        // Play the appropiate hit sound
                        PlayHitSound();
                    }
                }
            }
            else if(playerScript.holdingTool())
            {   
               // In case that the player does not need the material, we set the error text to true.
                errorText.SetActive(true);
                StartCoroutine(hideError(5.0f));
                SoundManager.Instance.PlayIncorrect();
            }

        }
       
    }
    
    // Function responsible for playing the appropiate hit sound.
    private void PlayHitSound()
    {
        switch (gameObject.tag)
        {
            case "Stone":
                SoundManager.Instance.PlayStoneMining();
            break;
        
            case "Wood":
                SoundManager.Instance.PlayWoodChopping();
            break;

            case "Clay":
                SoundManager.Instance.PlayDigClay();
            break;
        }
    }

    // IEnumerator needed to hide the error message.
    private IEnumerator hideError(float delay)
    {
        yield return new WaitForSeconds(delay);
        errorText.SetActive(false);        
    }
}
