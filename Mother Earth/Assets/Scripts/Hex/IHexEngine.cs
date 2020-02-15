using System.Collections;
using System.Collections.Generic;

interface IHexEngine
{
    void Tick();
    void Die();
    void Live();
    HexState IsAlive();
}