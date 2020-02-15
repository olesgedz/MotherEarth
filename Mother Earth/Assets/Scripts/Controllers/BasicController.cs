using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicController : MonoBehaviour, IController
{
    private bool run = false;

    public abstract void Execute();

    public void ControllerStart()
    {
        run = true;
    }

    public void ControllerStop()
    {
        run = false;
    }
    public bool IsRun()
    {
        return run;
    }
}