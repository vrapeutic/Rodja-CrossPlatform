using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendStatistics : MonoBehaviour
{
    BackendSession currentSession;
    DataCollection dataCollection;
    private void Awake()
    {
        currentSession = FindObjectOfType<BackendSession>();
        dataCollection = FindObjectOfType<BackendSession>().MyStats;
    }
    public void UpdateData()
    {
        TovaDataGet.ReturnTovaData().SetSessionEnd(true);    
        Invoke("SendUpdatedData", 1f);
    }

    public void SendUpdatedData()
    {
        dataCollection.response_time = TovaDataGet.ReturnTovaData().GetTotalResponseTime();
        dataCollection.impulsivity_score = TovaDataGet.ReturnTovaData().GetTotalImpsScore();
        dataCollection.omission_score = TovaDataGet.ReturnTovaData().GetTotalOmissionScore();
      
        currentSession.SendStatsData();
    }
}
