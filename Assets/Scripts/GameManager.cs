using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void EndSession()
    {
        TovaDataGet.ReturnTovaData().SetSessionEnd(true);
        Invoke("PrintStatistics", 2f);
    }
    private void PrintStatistics()
    {
        Debug.Log("Response Time: " + TovaDataGet.ReturnTovaData().GetTotalResponseTime());
        Debug.Log("Impulsivity Score: " + TovaDataGet.ReturnTovaData().GetTotalImpsScore());
        Debug.Log("Omission Score: " + TovaDataGet.ReturnTovaData().GetTotalOmissionScore());
        Debug.Log("DES: " + TovaDataGet.ReturnTovaData().GetTotalDES());
        Debug.Log("Total num of destractor: " + TovaDataGet.ReturnTovaData().GetTotalNumOfDistractorHit());
        Debug.Log("Total num of Targets: " + TovaDataGet.ReturnTovaData().GetTotalNumOfTargets());
        Debug.Log("Total num of tries: " + TovaDataGet.ReturnTovaData().GetTotalNumOfTries());
    }
}
