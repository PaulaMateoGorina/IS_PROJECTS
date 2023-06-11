using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Class defining the behaviour of the submissions.
*/

public class Submission: MonoBehaviour
{

    public GameObject res;

    public int woodNeeded;
    public int stoneNeeded;
    public int clayNeeded;
    public int waterNeeded;
    public float remainingTime;
    public GameObject materialStage;

    public string buildingName;

    public int materialsNeeded;

    void Start()
    {
        //Set the number of needed materials to the total sum
        materialsNeeded = woodNeeded + stoneNeeded + clayNeeded + waterNeeded;
    }

    // Function that updates all the texts
    public void updateAll()
    {
        OrderManager.Instance.UpdateTitleText(buildingName);
        OrderManager.Instance.UpdateWoodText(woodNeeded);
        OrderManager.Instance.UpdateStoneText(stoneNeeded);
        OrderManager.Instance.UpdateClayText(clayNeeded);
        OrderManager.Instance.UpdateWaterText(waterNeeded);
        OrderManager.Instance.UpdateTimeText((int)Mathf.Ceil(remainingTime));
    }

    // Function that updates the remaining time
    public virtual void updateTime(){
        remainingTime = Mathf.Max(remainingTime - Time.deltaTime, 0.0f ) ;
        if(remainingTime == 0.0f){
            SubmissionManager.Instance.submissionOver(true);
        }
        OrderManager.Instance.UpdateTimeText((int) Mathf.Ceil(remainingTime));
    }

    // Function that updates the needed materials
    public void updateMaterialsNeeded(string materialName)
    {
        switch (materialName)
        {
            case "Wood":
                woodNeeded--;
                OrderManager.Instance.UpdateWoodText(woodNeeded);
                break;

            case "Stone":
                Debug.Log("Entered submission switch");
                stoneNeeded--;
                OrderManager.Instance.UpdateStoneText(stoneNeeded);
                break;

            case "Clay":
                clayNeeded--;
                OrderManager.Instance.UpdateClayText(clayNeeded);
                break;
            case "Water":
                waterNeeded--;
                OrderManager.Instance.UpdateWaterText(waterNeeded);
                break;
        }
        materialsNeeded--;

        checkFinished();
    }

    // Function that returns whether we have finished or not.
    public virtual void checkFinished()
    {
        if (materialsNeeded == 0)
        {
            Debug.Log("finished!");
            Instantiate(res, transform);
            SubmissionManager.Instance.submissionOver(false);
        }
        else
        {
            SoundManager.Instance.PlayCorrect();
        }
    }

    // Function that returns whether a meterial is needed or not. 
    public bool isMaterialNeeded(string materialName)
    {
        switch (materialName)
        {
            case "Wood":
                return woodNeeded > 0;
            case "Stone":
                return stoneNeeded > 0;

            case "Clay":
                return clayNeeded > 0;
            case "Water":
                return waterNeeded > 0;
        }
        return false;   
    }
}
