using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnClassifiedJewelsLogic : MonoBehaviour
{
    [SerializeField] IntVariable redJewelsNo;
    [SerializeField] IntVariable blueJewelsNo;
    [SerializeField] IntVariable goldJewelsNo;
    [SerializeField] GameObject[] redJewels;
    [SerializeField] GameObject[] blueJewels;
    [SerializeField] GameObject[] goldJewels;

    // Start is called before the first frame update
    void Start()
    {
        ShowUnClassifiedJewels();
    }

    void ShowUnClassifiedJewels()
    {
        for (int i = 0; i < redJewels.Length; i++)
        {
            if (i < redJewelsNo.Value) redJewels[i].SetActive(true);
            else redJewels[i].SetActive(false);
            if (i < blueJewelsNo.Value) blueJewels[i].SetActive(true);
            else blueJewels[i].SetActive(false);
            if (i < goldJewelsNo.Value) goldJewels[i].SetActive(true);
            else goldJewels[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
