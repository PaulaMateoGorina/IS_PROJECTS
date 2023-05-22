using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmissionManager : MonoBehaviour
{

    public static SubmissionManager Instance;

    public Submission[] submissions;
    private int curSubmission;
    private int numSubmissions;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        curSubmission = 0;

        // Fill the submissions array with the children of the manager
        numSubmissions = transform.childCount;
        submissions = new Submission[numSubmissions];
        for (int i = 0; i < numSubmissions; i++)
        {
            submissions[i] = transform.GetChild(i).gameObject.GetComponent<Submission>();
        }

    }
    void Update(){
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

    public void submissionOver(bool expired)
    {
        if (expired)
        {
            //TODO: GAMEOVER
        }
        else
        {
            //TODO: make materials visible again
            curSubmission++;
            if (curSubmission < numSubmissions)
                submissions[curSubmission].updateAll();
            //TODO: else - GAME FINISHED!!
        }
    }
}
