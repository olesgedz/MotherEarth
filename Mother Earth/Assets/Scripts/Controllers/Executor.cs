using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executor : MonoBehaviour
{
    // private BasicController[] controllers;
    private CMeteor controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<CMeteor>();
        controller.ControllerStart();
    }

    // Update is called once per frame
    void Update()
    {
        controller.Execute();
        // foreach (var controller in controllers)
        // {
        //     controller.Execute();
        // }
    }
}
