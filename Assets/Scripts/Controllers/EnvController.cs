using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvController : BasicController
{
    protected GameObject[] hexes;
    private void Start()
    {
        hexes = GameObject.FindGameObjectsWithTag("Hex");
    }

    public override void Execute()
    {
        if (base.IsRun())
        {

        }
    }
}
