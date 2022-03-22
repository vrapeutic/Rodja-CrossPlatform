using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetElements : MonoBehaviour
{
    [SerializeField]
    List<GameObject> roads= new List<GameObject>();
    [SerializeField]
    GameObject distractor;
    private void Awake()
    {
        if (FindObjectOfType<MenuManger>().menu.level > 1)
            distractor.SetActive(true);

        foreach(GameObject road in roads)
        {
            if (FindObjectOfType<MenuManger>().menu.Track_name != road.tag)
            {

                road.SetActive(false);
            }
            
        }
    }
}
