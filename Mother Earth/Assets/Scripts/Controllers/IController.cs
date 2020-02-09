using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    // Метод для выполнения одного локального обновления (local update)
    void Execute();
    void ControllerStart();
    void ControllerStop();
}

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

public class EnvController : BasicController
{
    private GameObject[] hexes;
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

