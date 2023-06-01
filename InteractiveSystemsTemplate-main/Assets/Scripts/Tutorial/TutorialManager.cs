using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    public GameObject stages;
    public GameObject slides1;

    private Slides slides1Script;
    private int curStep;

    void Awake()
    {
        Instance = this;
        slides1Script = slides1.GetComponent<Slides>();
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
                
                break;
        }
        curStep++;
    }
}
