using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public void UpdateTimeText(int time)
    {
        timeText.text = ( "Te daremos otro pedido en: " + time + "s");
    }
    public void updateBuildingText(string building)
    {
        buildingText.text = building;
    }

    
}
