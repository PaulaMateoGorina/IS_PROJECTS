using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Submission: MonoBehaviour
{

    public static Submission Instance;

    public GameObject result;

    public int woodNeeded;
    public int stoneNeeded;
    public int clayNeeded;
    public int waterNeeded;
    public float remainingTime;
    public GameObject materialStage;

    public string buildingName;

    private int materialsNeeded;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        materialsNeeded = woodNeeded + stoneNeeded + clayNeeded + waterNeeded;
    }

    void Start()
    {
     
    }

    void Update(){
    
    }

    public void updateAll()
    {
        OrderManager.Instance.UpdateWoodText(woodNeeded);
        OrderManager.Instance.UpdateStoneText(stoneNeeded);
        OrderManager.Instance.UpdateClayText(clayNeeded);
        OrderManager.Instance.UpdateWaterText(waterNeeded);
        OrderManager.Instance.UpdateTimeText((int)Mathf.Ceil(remainingTime));
    }

    public void updateTime(){
        remainingTime = Mathf.Max(remainingTime - Time.deltaTime, 0.0f ) ;
        if(remainingTime == 0.0f){
            SubmissionManager.Instance.submissionOver(true);
        }
        OrderManager.Instance.UpdateTimeText((int) Mathf.Ceil(remainingTime));
    }

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

        if(materialsNeeded == 0)
        {
            Debug.Log("finished!");
            Instantiate(result, transform);
            SubmissionManager.Instance.submissionOver(false);
        }
    }


    public bool isMaterialNeeded(string materialName)
    {
        switch (materialName)
        {
            case "Wood":
                return woodNeeded > 0;
                break;
            case "Stone":
                return stoneNeeded > 0;
                break;

            case "Clay":
                return clayNeeded > 0;
                break;
            case "Water":
                return waterNeeded > 0;
                break;
        }
        return false;   
    }
}
