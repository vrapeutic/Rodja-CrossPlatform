using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameEvent onEndSuccessfully;
    [SerializeField] BoolValue canPlay;
    [SerializeField] StringVariable typeOfAttention;
    [SerializeField] IntVariable sustainedValue;
    int collectedJewelries=0;
    int targetCollectedJewelries;
    private void Start()
    {
        canPlay.Value = true;
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
        collectedJewelries++;
        if (collectedJewelries >= targetCollectedJewelries)
        {
            Debug.Log("should End successfully");
            onEndSuccessfully.Raise();
            canPlay.Value = false;
        }    
    }
}
