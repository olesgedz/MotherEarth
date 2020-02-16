using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorLife : MonoBehaviour
{
    private CMeteor MeteorController;

    private void Start()
    {
        MeteorController = GameObject.FindGameObjectWithTag("Controller").GetComponent<CMeteor>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hex"))
        {
            MeteorController.Collision(gameObject, other.gameObject);
        }
    }
}
