using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmissionManager : MonoBehaviour
{

    public static SubmissionManager Instance;

    public Submission[] submissions;
    public Transform materials;
    public GameObject successMessage;
    
    private int curSubmission;
    private int numSubmissions;
    private bool inSuccess;
    private float successMessageTime;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        curSubmission = 0;
        successMessageTime = 5.0f;

        // Fill the submissions array with the children of the manager
        numSubmissions = transform.childCount;
        submissions = new Submission[numSubmissions];
        for (int i = 0; i < numSubmissions; i++)
        {
            submissions[i] = transform.GetChild(i).gameObject.GetComponent<Submission>();
        }

        // Make the success message invisible at the start
        successMessage.SetActive(false);
    }

    void Start()
    {
        
        Instantiate(submissions[curSubmission].materialStage, materials);
    }

    void Update(){

        // If we are showing the success message, update the time remaining for the next order
        if(inSuccess){
            successMessageTime = Mathf.Max(successMessageTime - Time.deltaTime, 0.0f);
            SuccessMessage messageScript = successMessage.GetComponent<SuccessMessage>();
            messageScript.UpdateTimeText((int) Mathf.Ceil(successMessageTime));
            if(successMessageTime == 0.0f){
                inSuccess = false;
            }
        }
        //TODO: remove this unnecessary condition when the success scene is made
        else if(curSubmission < numSubmissions)
        // Update the text indicating the time remaining for the submission otherwise
            OrderManager.Instance.UpdateTimeText((int) Mathf.Ceil(submissions[curSubmission].remainingTime));

   

    }

    public void updateMaterialsNeeded(string materialName)
    {
        submissions[curSubmission].updateMaterialsNeeded(materialName);
    }


    public bool isMaterialNeeded(string materialName)
    {
        return submissions[curSubmission].isMaterialNeeded(materialName);
    }

    private void newSubmission()
    {
        // Destroy the previous submission result
        Destroy(submissions[curSubmission].transform.GetChild(0).gameObject); 
        
        // Make the success message invisible again
        successMessage.SetActive(false);

        // Change the submission, update the order texts and instantiate the materials associated with the submission
        curSubmission++;
        if (curSubmission < numSubmissions)
        {
            submissions[curSubmission].updateAll();
            Instantiate(submissions[curSubmission].materialStage, materials);
        }
    }

    public void submissionOver(bool expired)
    {
        if (expired)
        {
            //TODO: GAMEOVER
        }
        else
        {
            // Destroy the current stage materials and show the success message
            Destroy(materials.GetChild(0).gameObject);
            inSuccess = true;
            successMessageTime = 5.0f;
            successMessage.SetActive(true);

            Invoke("newSubmission", 5);

            //TODO: else - GAME FINISHED!!
        }
    }
}
