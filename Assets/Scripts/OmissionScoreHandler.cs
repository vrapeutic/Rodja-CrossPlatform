
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmissionScoreHandler : MonoBehaviour
{
    public void StartActualTime(){
        TovaDataGet.ReturnTovaData().SetActualTimeCounter(true);
    }
    public void StopActualTime(){
        TovaDataGet.ReturnTovaData().SetActualTimeCounter(false);
    }
}
