using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class responseTimeHandler : MonoBehaviour
{
   public void StartResponseTime()
    {
        TovaDataGet.ReturnTovaData().isResponseTimer = true;
    }

    public void StopResponseTime()
    {
        TovaDataGet.ReturnTovaData().isResponseTimer = false;
    }
}
