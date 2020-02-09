using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executor : MonoBehaviour
{
    private BasicController[] controllers;
    // Start is called before the first frame update
    void Start()
    {
        //Найти все контроллеры
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var controller in controllers)
        {
            controller.Execute();
        }
    }
}
