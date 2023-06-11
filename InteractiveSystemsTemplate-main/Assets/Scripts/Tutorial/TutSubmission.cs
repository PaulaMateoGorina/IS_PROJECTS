using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Stage that controls the behaviour of the submission are of the tutorial
*/

public class TutSubmission: Submission
{
    void Start()
    {
        materialsNeeded = woodNeeded + stoneNeeded + clayNeeded + waterNeeded;
    }

    // There is no time in the tutorial
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
