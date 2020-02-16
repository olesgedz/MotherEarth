using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executor : MonoBehaviour
{
    // private BasicController[] controllers;
    private MeteorController meteorController;
    private HexController hexController;
    // Start is called before the first frame update
    void Start()
    {
        meteorController = GameObject.FindGameObjectWithTag("MeteorController").GetComponent<MeteorController>();
        meteorController.ControllerStart();
        hexController = GameObject.FindGameObjectWithTag("HexController").GetComponent<HexController>();
        hexController.ControllerStart();
    }

    // Update is called once per frame
    void Update()
    {
        hexController.Execute();
        meteorController.Execute();
    }
}
