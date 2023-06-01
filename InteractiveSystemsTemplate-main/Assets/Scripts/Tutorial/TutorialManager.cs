using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    public GameObject stages;
    public GameObject slides1;
    public GameObject slides2;
    public GameObject slides3;

    private Slides slides1Script;
    private Slides slides2Script;
    private Slides slides3Script;
    private int curStep;

    void Awake()
    {
        Instance = this;
        slides1Script = slides1.GetComponent<Slides>();
        slides2Script = slides2.GetComponent<Slides>();
        slides3Script = slides3.GetComponent<Slides>();
    }

    // Start is called before the first frame update
    void Start()
    {
        curStep = 0;
        stages.SetActive(false);
    }

    public void next()
    {
        switch (curStep)
        {
            case 0:
                slides1Script.showSlides();
                break;
            case 1:
                slides1.SetActive(false);
                stages.SetActive(true);
                TutorialStages.Instance.startStage1();
                break;
            case 2:
                TutorialStages.Instance.endStage1();
                stages.SetActive(false);
                slides2Script.showSlides();
                break;
            case 3:
                slides2.SetActive(false);
                stages.SetActive(true);
                TutorialStages.Instance.startStage2();
                break;
            case 4:
                TutorialStages.Instance.endStage2();
                stages.SetActive(false);
                slides3Script.showSlides();
                break;
            case 5:
                SceneManager.LoadScene("Scene");
                break;
        }
        curStep++;
    }
}
