using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//three types of attention determine which distractor will appear sustained(no distractor),selective(distractor with no action needed)
//and adaptive (distractor with action needed)
public class DistractorManager : MonoBehaviour
{
    [SerializeField] StringVariable typeOfAttention;
    [SerializeField] IntVariable noOfDistractors;
    [SerializeField] BoolValue canPlay;
    //selective attention 
    [SerializeField] GameEvent OnSelectiveTask1;
    [SerializeField] GameEvent OnSelectiveTask2;
    [SerializeField] GameEvent OnSelectiveTask3;
    //adaptive attention
    [SerializeField] GameEvent OnAdaptiveTask1;
    [SerializeField] GameEvent OnAdaptiveTask2;
    [SerializeField] GameEvent OnAdaptiveTask3;

    // Start is called before the first frame update
    void Start()
    {
        if (typeOfAttention.Value == "selective") SelectiveAttention();
        else if (typeOfAttention.Value == "adaptive") AdaptiveAttention();
    }

    async void SelectiveAttention()
    {
        await new WaitForSeconds(20);
        while (canPlay.Value)
        {
            int rand = RandomNember();
            if (rand == 1) OnSelectiveTask1.Raise();
            else if (rand == 2) OnSelectiveTask2.Raise();
            else if (rand == 3) OnSelectiveTask3.Raise();
            await new WaitForSeconds(30);
        }
    }

    public async void AdaptiveAttention()
    {
        int rand = RandomNember();
        //Debug.Log("AdaptiveAttention"+rand);
        await new WaitForSeconds(20);
        if (rand == 1) OnAdaptiveTask1.Raise();
        else if (rand == 2) OnAdaptiveTask2.Raise();
        else if (rand == 3) OnAdaptiveTask3.Raise();
    }

    int RandomNember()
    {
        int maxRange = noOfDistractors.Value + 1;
        return Random.Range(1, maxRange);
    }
}
