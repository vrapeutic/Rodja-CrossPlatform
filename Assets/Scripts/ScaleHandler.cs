using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScaleHandler : MonoBehaviour
{
    [SerializeField]
    List<JewelryManager> jewelries;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        jewelries = this.GetComponentsInChildren<JewelryManager>().ToList();

    }

    public void ScaleCurrentJewelry()
    {
        jewelries[index].ScaleJewelry();
        index++;
    } 
}
