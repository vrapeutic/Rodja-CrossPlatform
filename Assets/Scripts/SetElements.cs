using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetElements : MonoBehaviour
{
    [SerializeField]
    List<GameObject> roads = new List<GameObject>();
    [SerializeField]
    GameObject distractor;

    [SerializeField]
    GameObject agent;
    private void Awake()
    {
       
        Debug.Log(FindObjectOfType<MenuManger>().menu.Character);
        if (FindObjectOfType<MenuManger>().menu.level > 1)
        {
            TovaDataGet.ReturnTovaData().SetDistractorEnabled(true);
            distractor.SetActive(true);
        }
        if (FindObjectOfType<MenuManger>().menu.Character != "boy")
           agent.transform.GetChild(0).gameObject.SetActive(false);
        else agent.transform.GetChild(1).gameObject.SetActive(false);

        foreach (GameObject road in roads)
        {
            if (FindObjectOfType<MenuManger>().menu.Track_name != road.tag)
            {

                road.SetActive(false);
            }

        }
    }
}
