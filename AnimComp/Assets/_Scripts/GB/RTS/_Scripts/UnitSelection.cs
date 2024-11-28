using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitSelection : MonoBehaviour
{
    public static UnitSelection Instance {get; set;}

    [Header("Unit's List")]
    public List<GameObject> allUnits = new List<GameObject>();
    public List<GameObject> selectedUnits = new List<GameObject>();

    [Header("Masks")]
    [SerializeField] private LayerMask _clickableLayer;

    private UnitController _inputActions;
    private Camera _mainCam;

    private void Awake() 
    {
        
        if(Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            InitInstance();
        }
    }

    private void InitInstance()
    {
        _mainCam = Camera.main;
        _inputActions = new UnitController();
        _inputActions.Selection.SelectUnit.performed += CheckSelection;
        UnitMovement.OnUnitDoneMovement += DeselectAll;
        _inputActions.Enable();
    }

    private void CheckSelection(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, _clickableLayer))
        {
            SelectUnit(hit.collider.gameObject);
        }
    }

    private void DeselectAll(GameObject unitEvent)
    {
        foreach(GameObject unit in selectedUnits)
        {
            Unit unitScript = unit.GetComponent<Unit>();
            unitScript.DisableUnitMovement();
        }

        selectedUnits.Clear();
    }

    

    private void SelectUnit(GameObject unit)
    {
        if(!selectedUnits.Contains(unit))
        {
            selectedUnits.Add(unit);
            UpdateUnitMovementStatus(unit, true);
        }

    }


    private void UpdateUnitMovementStatus(GameObject unit, bool shouldMove)
    {
       Unit unitScript = unit.GetComponent<Unit>();

        if(shouldMove)
        {
            unitScript.EnableUnitMovement();
        }
        else
        {
            unitScript.DisableUnitMovement();
        }
    }




}
