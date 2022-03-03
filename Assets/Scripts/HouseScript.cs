using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    private RaycastHit RayHit;
    bool IsDeployed = false;

    //List<GameObject> Houses;

    void Update()
    {
        if (UnitManager.IsInstantiated == false || IsDeployed == true)
            return;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RayHit, Mathf.Infinity))
        {
            transform.position = new Vector3(RayHit.point.x, 0, RayHit.point.z);

            Debug.DrawRay(RayHit.point, Vector3.up);

            if (Input.GetMouseButtonDown(0) && UnitManager.IsInstantiated == true)
            {
                DeployHouse();
                UnitManager.IsInstantiated = false;
            }
        }

        //TO-DO: Deploy on click, use bool IsButtonClicked to be able and use mouseButton(O) for Deploy
    }

    void DeployHouse()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RayHit, Mathf.Infinity))
        {
            if (!IsDeployed)
            {
                IsDeployed = true;
                transform.position = transform.position;
            }

            //Houses.Add(this.gameObject);
        }
    }
}
