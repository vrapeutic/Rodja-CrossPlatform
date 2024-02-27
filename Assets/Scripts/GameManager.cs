using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameEvent onEndSuccessfully;
    [SerializeField] GameEvent onEndUnSuccessfully;
    [SerializeField] BoolValue canPlay;
    [SerializeField] StringVariable typeOfAttention;
    [SerializeField] IntVariable sustainedValue;
    int collectedJewels;
    int targetCollectedJewelries;
    private void Start()
    {
        canPlay.Value = true;
        collectedJewels = 0;
        if (typeOfAttention.Value == "sustained")
        {
            if (sustainedValue.Value == 20) targetCollectedJewelries=5;
            else if (sustainedValue.Value == 40) targetCollectedJewelries=10;
            else if (sustainedValue.Value == 60) targetCollectedJewelries=15;
        }
        else targetCollectedJewelries=10;
    }

    public void CollectingJewelry()
    {
        collectedJewels++;
        if (collectedJewels >= targetCollectedJewelries)
        {
            onEndSuccessfully.Raise();
            StopPlaying();
        }    
    }

    public void EndUnSeccessfully()
    {
        onEndUnSuccessfully.Raise();
        StopPlaying();
    }

    public void StopPlaying()
    {
        canPlay.Value = false;
    }

    public void ContinuePlaying()
    {
        canPlay.Value = true;
    }

}
