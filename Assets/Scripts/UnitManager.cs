using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    public List<Unit> Selection;
    public LayerMask UnitLayer;

    public LayerMask Ground;

    private RaycastHit RayHit;

    [SerializeField] GameObject Prefab;
    public static bool IsInstantiated = false;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RayHit, Mathf.Infinity, UnitLayer))
            {
                Unit unit = RayHit.collider.GetComponent<Unit>();

                if (!Selection.Contains(unit))
                {
                    unit.SelectUnit();
                    Selection.Add(unit);
                }
            }
            else
            {
                foreach (Unit selected in Selection)
                {
                    Debug.Log("Deselected");
                    selected.DeselectUnit();
                }

                Selection.Clear();
            }
        }

        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RayHit, Mathf.Infinity, Ground))
            {
                foreach(Unit unit in Selection)
                {
                    unit.GetComponent<NavMeshAgent>().SetDestination(RayHit.point);
                }
            }
        }
    }

    public void SpawnHouse(GameObject housePrefab)
    {
        housePrefab = Instantiate(Prefab);
        Debug.Log("Instantiated");
        IsInstantiated = true;
    }
}
