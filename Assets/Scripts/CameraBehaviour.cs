using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    int EdgeAllowance = 10;
    float MoveSpeed = 3.0f;

    void Update()
    {
        //right edge
        if (Input.mousePosition.x >= Screen.width - EdgeAllowance)
            transform.position += Vector3.right * Time.deltaTime * MoveSpeed;

        //left edge
        if (Input.mousePosition.x <= 0 + EdgeAllowance)
            transform.position += Vector3.left * Time.deltaTime * MoveSpeed;

        //upper edge
        if (Input.mousePosition.y >= Screen.height - EdgeAllowance)
            transform.position += Vector3.forward * Time.deltaTime * MoveSpeed;

        //lower edge
        if (Input.mousePosition.y <= 0 + EdgeAllowance)
            transform.position += Vector3.back * Time.deltaTime * MoveSpeed;
    }
}
