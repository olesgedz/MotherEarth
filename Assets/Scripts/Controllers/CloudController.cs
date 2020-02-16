using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : EnvController
{
    [SerializeField] List<GameObject> clouds;
    [SerializeField] GameObject cloudPreb;
    private PlanetController planet;


    // Start is called before the first frame update
    void Start()
    {
        hexes = GameObject.FindGameObjectsWithTag("Hex");
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<PlanetController>();
    }

    public override void Execute()
    {
        if (base.IsRun())
        {

            //this.SpawnCloud();
            //foreach (GameObject hex in hexes)
            //{
            //    Debug.Log(hex.GetComponent<BasicHexEngine>().IsAlive());
            //}
        }
    }

    public void SpawnCloud()
    {
        Debug.Log("New cloud");
        GameObject newCloud = Instantiate(cloudPreb, planet.transform.position, Quaternion.identity) as GameObject;
        newCloud.transform.LookAt(planet.transform.position);
        clouds.Add(newCloud);
    }
}
