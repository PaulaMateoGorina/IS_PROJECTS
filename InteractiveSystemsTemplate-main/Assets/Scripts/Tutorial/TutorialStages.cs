using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialStages : MonoBehaviour
{
    public static TutorialStages Instance;

    public GameObject stage1;
    public GameObject stage2;
    public GameObject orderPlace;
    public GameObject helpSign;

    private Slides slides1Script;
    private int curStep;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        stage1.SetActive(false);
        stage2.SetActive(false);
        orderPlace.SetActive(false);
        helpSign.SetActive(false);
    }

    public void startStage1()
    {
        stage1.SetActive(true);
        orderPlace.SetActive(false);
    }

    public void endStage1()
    {
        stage1.SetActive(false);
    }

    public void startStage2()
    {
        stage2.SetActive(true);
        orderPlace.SetActive(true);
        helpSign.SetActive(true);
    }

    public void endStage2()
    {
        stage2.SetActive(false);
        orderPlace.SetActive(false);
        helpSign.SetActive(false);
    }
}
