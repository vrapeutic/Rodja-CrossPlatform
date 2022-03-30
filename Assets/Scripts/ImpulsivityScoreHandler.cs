using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulsivityScoreHandler : MonoBehaviour
{
    private void Start()
    {
        TovaDataGet.ReturnTovaData().SetTargetsCounterEnabled(true);
    }
    public void StartTargetCounter()
    {
        TovaDataGet.ReturnTovaData().SetTargetsCounterEnabled(true);
        Debug.Log(TovaDataGet.ReturnTovaData().GetTotalNumOfTargets());
    }

}
