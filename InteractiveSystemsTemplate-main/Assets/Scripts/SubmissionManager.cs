using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        submissions[curSubmission].updateAll();
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
            submissions[curSubmission].updateTime();
         //  OrderManager.Instance.UpdateTimeText((int) Mathf.Ceil(submissions[curSubmission].remainingTime));

   

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
        // Destroy the current stage materials and show the success message
        Destroy(materials.GetChild(0).gameObject);

        // Destroy the previous submission result
        Destroy(submissions[curSubmission].transform.GetChild(0).gameObject);

        // Update the number of submissions
        curSubmission++;

        if (curSubmission < numSubmissions)
        {
            inSuccess = true;
            successMessageTime = 5.0f;
            successMessage.SetActive(true);

            // Start the delay coroutine
            StartCoroutine(DelayedExecution(5.0f));
        }
        else
        {
            SceneManager.LoadScene("SuccessScene");
        }
    }

    public void submissionOver(bool expired)
    {
        if (expired)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            newSubmission();
        }
    }

    private IEnumerator DelayedExecution(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Continue with the execution after the delay
        // Make the success message invisible again
        successMessage.SetActive(false);

        // Instantiate the new submission and the materials
        submissions[curSubmission].updateAll();
        Instantiate(submissions[curSubmission].materialStage, materials);
    }
}