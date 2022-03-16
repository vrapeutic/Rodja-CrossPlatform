using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OpenNextJewelry : MonoBehaviour
{
    [SerializeField]
    List<MeshRenderer> jewelries;
    int index = 1;
    // Start is called before the first frame update
    void Start()
    {
        jewelries = this.GetComponentsInChildren<MeshRenderer>().ToList();
    }

    public void ActivateNextJewelry()
    {
        if (index < jewelries.Count)
        {
            jewelries[index].enabled = true;
            index++;
        }
    }
}
