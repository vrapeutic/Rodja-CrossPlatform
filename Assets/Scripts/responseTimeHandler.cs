using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class responseTimeHandler : MonoBehaviour
{
    private void Start()
    {
        TovaDataGet.ReturnTovaData().SetNoOfTriesCounter(true);
    }
    public void StartResponseTime()
    {
        TovaDataGet.ReturnTovaData().isResponseTimer = true;
        TovaDataGet.ReturnTovaData().SetNoOfTriesCounter(true);
    }

    public void StopResponseTime()
    {
        TovaDataGet.ReturnTovaData().isResponseTimer = false;
    }
}
