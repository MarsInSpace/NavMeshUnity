using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] GameObject SelectionCircle;
    public void SelectUnit()
    {
        SelectionCircle.SetActive(true);
    }

    public void DeselectUnit()
    {
        SelectionCircle.SetActive(false);
    }
}
