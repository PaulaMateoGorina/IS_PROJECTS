using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;

    public TMP_Text woodText;
    public TMP_Text stoneText;
    public TMP_Text clayText;
    public TMP_Text waterText;
    public TMP_Text timeText;

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void UpdateWoodText(int wood)
    {
        woodText.text = "Wood x" + wood;
    }

    // Update is called once per frame
    public void UpdateStoneText(int stone)
    {
        stoneText.text = "Stone x" + stone;
    }

    // Update is called once per frame
    public void UpdateClayText(int clay)
    {
        clayText.text = "Clay x" + clay;
    }

    // Update is called once per frame
    public void UpdateWaterText(int water)
    {
        waterText.text = "Water x" + water;
    }

    public void UpdateTimeText(int time){
        timeText.text = "Quedan: " + time + "s";
    }
}
