using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;

    public TextMeshProUGUI orderText;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI clayText;
    public TextMeshProUGUI waterText;
    public TextMeshProUGUI timeText;

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void UpdateWoodText(int wood)
    {
        woodText.text = "Wood x" + wood.ToString();
    }

    // Update is called once per frame
    public void UpdateStoneText(int stone)
    {
        stoneText.text = "Stone x" + stone.ToString();
    }

    // Update is called once per frame
    public void UpdateClayText(int clay)
    {
        clayText.text = "Clay x" + clay.ToString();
    }

    // Update is called once per frame
    public void UpdateWaterText(int water)
    {
        waterText.text = "Water x" + water.ToString();
    }
}
