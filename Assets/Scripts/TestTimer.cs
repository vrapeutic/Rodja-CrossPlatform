using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimer : MonoBehaviour
{
    [SerializeField]
    float maxTime;
    [SerializeField]
    GameEvent playerLoose;
    [SerializeField]
    float timer;

    private void Start()
    {
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > maxTime) playerLoose.Raise();
    }
}
