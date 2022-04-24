using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    string fileName;
    string attempStartTime;
    string attempEndTime;


   
    private void Start()
    {
        attempStartTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
        fileName = Application.dataPath + "/statistics.csv";
        WriteCSV();
    }

    public void EndSession()
    {
        attempEndTime = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
        TovaDataGet.ReturnTovaData().SetSessionEnd(true);
        Invoke("WriteFinalStatistics", 2f);
    }
    private void WriteCSV()
    {
        if (File.Exists(fileName))
        {
            Debug.Log("file created");
        }
        else
        {
            InitiateStateVaribaleFields();
        }
    }
    public void WriteFinalStatistics()
    {
        TextWriter myTextWriter = new StreamWriter(fileName, true);
        myTextWriter.WriteLine(attempStartTime + "," + attempEndTime + "," + FindObjectOfType<MenuManger>().menu.level + ","
           + TovaDataGet.ReturnTovaData().GetTotalImpsScore() + "," + TovaDataGet.ReturnTovaData().GetTotalResponseTime() + "," + TovaDataGet.ReturnTovaData().GetTotalNumOfTargets() + "," + TovaDataGet.ReturnTovaData().GetTotalOmissionScore() + "," + TovaDataGet.ReturnTovaData().GetTotalDES()
           /*+ "," + statsResponse + "," + statsOmission + "," + statsImpulsivity*/);
        myTextWriter.Close();
        Debug.Log("stats should be written");
    }
    private void InitiateStateVaribaleFields()
    {
        TextWriter myTextWriter = new StreamWriter(fileName, false);
        myTextWriter.WriteLine("session start time,attempt end time, level"+
            "impulisvity score,response time,score,omission score,distraction endurance score" + ", " +
            "stats Response time, states Omission score, states Impulsivity Score");
        myTextWriter.Close();
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
