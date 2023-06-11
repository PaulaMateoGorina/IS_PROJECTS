using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
This class controls the behaviour of the Success Message that appears when the players finish a submission
*/


public class SuccessMessage : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text  buildingText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Update the time remaining for the next submission
    public void UpdateTimeText(int time)
    {
        timeText.text = (time + "s");
    }

    // Update the name of the building that has been finished. 
    public void updateBuildingText(string building)
    {
        buildingText.text = building;
    }

    
}
