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
    }
}
