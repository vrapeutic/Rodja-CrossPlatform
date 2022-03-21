using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetElements : MonoBehaviour
{
    [SerializeField]
    List<MeshFilter> roads= new List<MeshFilter>();
    [SerializeField]
    GameObject distractor;
    private void Awake()
    {
        if (FindObjectOfType<MenuManger>().menu.level > 1)
            distractor.SetActive(true);
           foreach(MeshFilter road in roads)
        {
           if (FindObjectOfType<MenuManger>().menu.Track_name != road.name)
            {
                road.transform.parent.gameObject.SetActive(false);
            }
            
        }
            }
}
