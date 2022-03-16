using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelryManager : MonoBehaviour
{
    private Vector3 scaleChange;
    bool runScaleUp = false;
    private void Start()
    {
        scaleChange = new Vector3(0.5f, 0.5f, 0.5f);
    }

    private void Update()
    {
        if(runScaleUp && this.gameObject.transform.localScale.x <= 1.5f)
        {
            this.gameObject.transform.localScale += scaleChange * Time.deltaTime;   
        }
    }

    public void ScaleJewelry()
    {
        runScaleUp = true;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }
}
