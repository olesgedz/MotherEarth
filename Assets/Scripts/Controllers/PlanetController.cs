using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//- Doesn't work as intendent
//- Need to add raycasting

public class PlanetController : EnvController
{
    // Start is called before the first frame update
    private float xPosLast = 0, yPosLast = 0;
    private float xPosPres = 0, yPosPres = 0;
    private float xOffset = 0, yOffset = 0;
    private bool first = true;
    private Transform rig;
    private GameObject camera;


    [SerializeField] float sensitivity;
    void Start()
    {
        rig = this.gameObject.GetComponent<Transform>();
        camera = GameObject.FindWithTag("MainCamera");
    }

    public GameObject[] GetHexArray()
    {
        return this.hexes;
    }


    public override void Execute()
    {

        if (base.IsRun())  // Can't we get it outside of every object script?
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
               
                Ray ray = camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
               
                if (Physics.Raycast(ray, out hit) || !first)
                {
                   

                    if (!first || (hit.transform && hit.transform.name == "Planet"))
                    {
                        if (first)
                        {
                            xPosLast = Input.mousePosition.x;
                            yPosLast = Input.mousePosition.y;
                            first = false;
                        }
                        xPosPres = Input.mousePosition.x;
                        yPosPres = Input.mousePosition.y;
                        xOffset = xPosLast - xPosPres;
                        yOffset = yPosPres - yPosLast;
                        xPosLast = xPosPres;
                        yPosLast = yPosPres;
                        float yaw = xOffset * sensitivity;
                        float pitch = yOffset * sensitivity;
                        //rig.transform.Rotate(new Vector3(0, 1, 0), yaw);
                        //rig.transform.Rotate(new Vector3(1, 0, 0), pitch);
                        rig.RotateAround(rig.position, camera.transform.up, yaw);
                        rig.RotateAround(rig.position, camera.transform.right, pitch);
                    }
                }
            }
            else
            {
                first = true; 
            }
        }
    }
}
