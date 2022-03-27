using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestractorLevelHandling : MonoBehaviour
{
    MenuManger menuManger;
    void Awake()
    {
        if (FindObjectOfType<MenuManger>().menu.level == 1) this.gameObject.SetActive(false);
        
    }

   
}
