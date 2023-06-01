using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutSubmission: Submission
{
    void Start()
    {
        materialsNeeded = woodNeeded + stoneNeeded + clayNeeded + waterNeeded;
    }

    public override void updateTime(){
        return;
    }

    public override void checkFinished()
    {
        if (materialsNeeded == 0)
        {
            TutorialManager.Instance.next();
        }
        else
        {
            SoundManager.Instance.PlayCorrect();
        }
    }
}
