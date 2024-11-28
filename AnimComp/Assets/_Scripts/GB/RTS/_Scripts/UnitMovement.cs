using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;


public class UnitMovement : MonoBehaviour
{

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _resourceLayer;

    private Camera _mainCam;
    private UnitInputsMap _inputActions;
    private bool _isWalking;
    private MeshStatus _meshStatus;
    
    public static event Action<GameObject> OnUnitDoneMovement;
    private void Awake() 
    {
        _mainCam = Camera.main;
        _inputActions = new UnitInputsMap();
        _isWalking = false;
    }

    private void OnEnable() 
    {
        _inputActions.Move.MakeMovement.performed += Move; 
        _inputActions.Enable();

    }

    private void OnDisable()
    {
        _inputActions.Move.MakeMovement.performed -= Move;
        _inputActions.Disable();
    }

    public bool Update()
    {
        
        if (_agent.remainingDistance <= _agent.stoppingDistance && _isWalking)
        {
            if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
            {
                _isWalking = false;
                OnUnitDoneMovement?.Invoke(this.gameObject);
                return false;
            }
        }

        return true && _isWalking;
    }


    private void Move(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        _meshStatus.positionToGo = Vector3.forward;
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _resourceLayer))
        {
            if(hit.collider.gameObject.TryGetComponent(out ResourcePositionHolder info))
            {
                _meshStatus.positionToGo = info.GrabOnePosition();

                if(_meshStatus.positionToGo == Vector3.zero)
                    _meshStatus.positionToGo = transform.position;
            }

            _agent.SetDestination(_meshStatus.positionToGo);
            _meshStatus.positionToLook = hit.collider.transform.position;
            _isWalking = true;     
            return;
        }

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _groundLayer))
        {
            _meshStatus.positionToGo = hit.point;
            _meshStatus.positionToLook = hit.point;
            _agent.SetDestination(_meshStatus.positionToGo);
            _isWalking = true;     
            return;
        }   
    }

    public MeshStatus GetMeshStatus => _meshStatus;

}

public struct MeshStatus
{
    public bool isStoped;
    public Vector3 positionToLook;
    public Vector3 positionToGo; 
}
