using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
This class controls the behaviour of the texts indicating the orders. 
*/

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;

    public TMP_Text woodText;
    public TMP_Text stoneText;
    public TMP_Text clayText;
    public TMP_Text waterText;
    public TMP_Text timeText;
    public TMP_Text title;

    void Awake()
    {
        Instance = this;
    }

    // Function to update all the different texts 
    
    public void UpdateWoodText(int wood)
    {
        woodText.text = "Wood x" + wood;
    }

    public void UpdateTitleText(string text )
    {
        title.text = text;
    }


    public void UpdateStoneText(int stone)
    {
        stoneText.text = "Stone x" + stone;
    }

    public void UpdateClayText(int clay)
    {
        clayText.text = "Clay x" + clay;
    }

    public void UpdateWaterText(int water)
    {
        waterText.text = "Water x" + water;
    }

    public void UpdateTimeText(int time){
        timeText.text = "Quedan: " + time + "s";
    }
}
