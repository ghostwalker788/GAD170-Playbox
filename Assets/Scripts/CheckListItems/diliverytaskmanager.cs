using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diliverytaskmanager : CheckListItem
{
    public int NumberOfCubesRequired;
    public int NumberOfCubesDilivered;

    public override bool IsComplete { get { return NumberOfCubesDilivered == NumberOfCubesRequired; } }

    public override float GetProgress()
    {
        return (float)NumberOfCubesDilivered / (float)NumberOfCubesRequired;
    }

    public override string GetStatusReadout()
    {
        return NumberOfCubesDilivered.ToString() + " / " + NumberOfCubesRequired.ToString();
    }

    public override string GetTaskReadout()
    {
        return "Diliver Blue Cubes";
    }

    public void OnBasketScored()
    {
        if (NumberOfCubesDilivered < NumberOfCubesRequired)
        {
            var ourData = new GameEvents.CheckListItemChangedData();
            ourData.item = this;
            ourData.previousItemProgress = GetProgress();

            NumberOfCubesDilivered++;

            GameEvents.InvokeCheckListItemChanged(ourData);
        }
    }
}
