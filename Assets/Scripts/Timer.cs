using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float maxTime;
    [SerializeField]
    GameEvent playerLoose;
    [SerializeField]
    float timer = 0;

    private void Start()
    {
        maxTime = FindObjectOfType<MenuManger>().menu.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (maxTime != 0) timer += Time.deltaTime;
        if (timer > maxTime)
        {
            playerLoose.Raise();
        }
    }
}
