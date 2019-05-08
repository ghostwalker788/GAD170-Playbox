using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRangeManager : CheckListItem
{
    public int TargetRangeHighScore;
    public int TargetRangeReqiredScore;

    public override bool IsComplete { get { return TargetRangeHighScore == TargetRangeReqiredScore; } }

    public override float GetProgress()
    {
        return (float)TargetRangeHighScore / (float)TargetRangeReqiredScore;
    }

    public override string GetStatusReadout()
    {
        return TargetRangeHighScore.ToString() + " / " + TargetRangeReqiredScore.ToString();
    }

    public override string GetTaskReadout()
    {
        return "Target Range";
    }

    public void OnBasketScored()
    {
        if (TargetRangeHighScore < TargetRangeReqiredScore)
        {
            var ourData = new GameEvents.CheckListItemChangedData();
            ourData.item = this;
            ourData.previousItemProgress = GetProgress();

            TargetRangeHighScore++;

            GameEvents.InvokeCheckListItemChanged(ourData);
        }
    }
}