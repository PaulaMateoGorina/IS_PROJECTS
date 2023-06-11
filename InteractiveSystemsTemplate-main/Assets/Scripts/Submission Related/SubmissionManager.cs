using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Function responsible for managing the submissions 
*/


public class SubmissionManager : MonoBehaviour
{

    public static SubmissionManager Instance;

    public Transform materials;
    public GameObject successMessage;
    
    private Submission[] submissions;
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
        //At the beggining we instanciate the corresponding submission
        Instantiate(submissions[curSubmission].materialStage, materials);
        // And update the text
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

    // Function to update materials needed of the current submission
    public void updateMaterialsNeeded(string materialName)
    {
        submissions[curSubmission].updateMaterialsNeeded(materialName);
    }

    // Funcion that cheks if the material is needed in the current submission
    public bool isMaterialNeeded(string materialName)
    {
        return submissions[curSubmission].isMaterialNeeded(materialName);
    }

    // Function that initialises the next submission if necesary. If there are no more submissions, loades success scene. 
    private void newSubmission()
    {
        // Destroy the current stage materials and show the success message
        Destroy(materials.GetChild(0).gameObject);

        // Update the number of submissions
        curSubmission++;

        if (curSubmission < numSubmissions)
        {
            inSuccess = true;
            successMessageTime = 10.0f;
            successMessage.SetActive(true);

            SuccessMessage messageScript = successMessage.GetComponent<SuccessMessage>();
            messageScript.updateBuildingText(submissions[curSubmission -1].buildingName);

            // Start the delay coroutine
            StartCoroutine(toSubmission(10.0f));
        }
        else
        {
            SceneManager.LoadScene("Success");
        }
    }

    // Function that finalices the submission. If the time is expired, loades the GameOver scene, if not instanciates the next submission. 
    public void submissionOver(bool expired)
    {
        if (expired)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {   
            SoundManager.Instance.PlayFinishedBuilding();
            newSubmission();
        }
    }

    // IEnumerator used to delay the end of submissions while the sucess message appears. 
    private IEnumerator toSubmission(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Continue with the execution after the delay

        // Destroy the previous submission result
        Destroy(submissions[curSubmission - 1].transform.GetChild(0).gameObject);

        // Make the success message invisible again
        successMessage.SetActive(false);

        // Instantiate the new submission and the materials
        submissions[curSubmission].updateAll();
        Instantiate(submissions[curSubmission].materialStage, materials);
    }
}