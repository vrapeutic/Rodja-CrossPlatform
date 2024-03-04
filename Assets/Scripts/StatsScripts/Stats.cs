using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] IntVariable level;
    [SerializeField] BoolValue canPlay;
    //times when we can start aiming or end for one target
    List<System.DateTime> startingTimes = new List<System.DateTime>();
    List<System.DateTime> endingTimes = new List<System.DateTime>();
    //ending time -starting time
    List<double> interruptionDurations = new List<double>();
    //for following Distractors
    List<string> DistractorsName = new List<string>();
    List<double> TimeFollowingDistractors = new List<double>();
    System.DateTime registerDistractorTime;
    [SerializeField] FloatVariable timeFollowingSelectiveDistractor;
    TextWriter tw;
    string FileName;
    private void Start()
    {
        Debug.Log(System.DateTime.Now.ToString());
        //RegisteringStartTimeForTargeting();
        FileName = Application.persistentDataPath + "/" + DateTime.Now.ToFileTime() + ".csv";
        Debug.Log(FileName);
    }

    public void RegisteringStartTimeForTargeting()
    {
        if (!canPlay.Value) return;
        startingTimes.Add(System.DateTime.Now);
        //Debug.Log("StartTimeForTargeting :" + startingTimes[startingTimes.Count - 1]);
    }

    public void RegisteringEndTimeForTargeting()
    {
        endingTimes.Add(System.DateTime.Now);
        //Debug.Log("EndTimeForTargeting :" + endingTimes[endingTimes.Count - 1]);
    }

    public void RegisteringInterraptions()
    {
        for (int i = 0; i < endingTimes.Count; i++)
        {
            interruptionDurations.Add((endingTimes[i] - startingTimes[i]).TotalSeconds);
            //Debug.Log("Interraptions " + (interruptionDurations.Count - 1) + ":" + interruptionDurations[interruptionDurations.Count - 1]);
        }
        //Debug.Log("Interaptions registered");
    }

    //if we are selective we will optain the distracting time from camera hitted the distractor
    //if we are adaptive we will optain the distracting time from difference between raise distractor event and complation of distractor
    public void RegisteringDistractorName(string name)
    {

        DistractorsName.Add(name);
        Debug.Log("RegisteringDistractorName :"+ name);
        registerDistractorTime = System.DateTime.Now;
        if (name == "Bird_passing" || name == "Visitors_waving_selective" || name == "Tractor_passing")
        {
            StartCoroutine(RegisteringDistractorFollowingTimeIenum());
        }
    }
    IEnumerator RegisteringDistractorFollowingTimeIenum()
    {
        if (!canPlay.Value) yield return null;
        yield return new WaitForSeconds(20);
        TimeFollowingDistractors.Add(timeFollowingSelectiveDistractor.Value);
        Debug.Log("DistractorFollowingTime " + DistractorsName[TimeFollowingDistractors.Count - 1] + ":" + TimeFollowingDistractors[TimeFollowingDistractors.Count - 1]);
    }

    public void RegisteringDistractorFollowingTime()//in case of adaptive
    {
        if (!canPlay.Value) return;
        TimeFollowingDistractors.Add((System.DateTime.Now - registerDistractorTime).TotalSeconds);
        Debug.Log("DistractorFollowingTime " + DistractorsName[TimeFollowingDistractors.Count - 1] + ":" + TimeFollowingDistractors[TimeFollowingDistractors.Count - 1]);
    }

    public void RegisteringLastDistractor()
    {
        Debug.Log("@@DistractorsName.Count " + DistractorsName.Count + "," + "imeFollowingDistractors.Count " + TimeFollowingDistractors.Count);
        if (DistractorsName.Count> TimeFollowingDistractors.Count&& DistractorsName.Count>0)
        {
            Debug.Log("DistractorsName.Count " + DistractorsName.Count + "," + "imeFollowingDistractors.Count "+ TimeFollowingDistractors.Count);
            TimeFollowingDistractors.Add((System.DateTime.Now - registerDistractorTime).TotalSeconds);
        }
    }

    public void WriteCSV()
    {
        tw = new StreamWriter(FileName, true);
        tw.WriteLine("Archeeko"+", "+ level.Value);
        tw.WriteLine("Target Starting Time" + ", " + "Target Hitting Time "+", "+ "Interruption Durations");
        for (int i = 0; i < endingTimes.Count; i++)
        {
            tw.WriteLine(startingTimes[i].ToString() + ", " + endingTimes[i].ToString()+", " + interruptionDurations[i].ToString());
        }
        tw.WriteLine("Distractor Name          " + ", " + "Time Following It");
        for (int i = 0; i < TimeFollowingDistractors.Count; i++)
        {
            tw.WriteLine(DistractorsName[i].ToFixedString(25,' ')+", "+ TimeFollowingDistractors[i].ToString());
        }
        tw.Close();
    }
}
