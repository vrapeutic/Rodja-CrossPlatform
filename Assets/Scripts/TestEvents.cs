using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvents : MonoBehaviour
{
 
  public void PlayerArrived()
    {
        Debug.Log("player arrived");
    }

    public void MoveToNext()
    {
        Debug.Log("Move to next listened");
    }
    public void OnPlayerWon()
    {
        Debug.Log("player won");
    }
    public void OnPlayerLoose()
    {
        Debug.Log("player loose");
    }
}
