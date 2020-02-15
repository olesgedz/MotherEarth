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
