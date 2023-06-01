using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialStages : MonoBehaviour
{
    public static TutorialStages Instance;

    public GameObject stage1;
    public GameObject stage2;

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
    }

    public void startStage1()
    {
        stage1.SetActive(true);
    }   
}
