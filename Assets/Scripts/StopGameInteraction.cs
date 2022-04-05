using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StopGameInteraction : MonoBehaviour
{
    [SerializeField]
    List<WayPointsPath> wayPointsPaths;

    // Start is called before the first frame update
    void Start()
    {
        wayPointsPaths = this.GetComponentsInChildren<WayPointsPath>().ToList();

    }

    public void stopInteraction()
    {
        for (int i = 0; i < wayPointsPaths.Count; i++)
        {
            wayPointsPaths[i].enabled = false;
        }
    }
}
