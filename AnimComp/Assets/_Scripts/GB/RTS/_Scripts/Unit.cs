using System;
using UnityEngine;

public class Unit : MonoBehaviour
{

    [SerializeField] private UnitAnimator _animator;
    [SerializeField] private UnitCollision _collision;
    [SerializeField] private UnitMovement _movement;


    
    private void Start() 
    {
        UnitSelection.Instance.allUnits.Add(gameObject);
    }

    private void OnDestroy() 
    {
        UnitSelection.Instance.allUnits.Remove(gameObject);
    }

    private void Update()
    {
        if(!_movement.enabled)
        {
            UpdateAnimator(_collision.GetTriggerStatus.resourceType);
            return;
        }
            

        if (!_collision.GetTriggerStatus.isColliding)
        {
            if (_movement.Update())
            {
                _animator.SetRunning();
            }
            else
            {
                _animator.SetIdle();
            }
        }
        else
            UpdateAnimator(_collision.GetTriggerStatus.resourceType);

    }

    private void UpdateAnimator(ResourceType typeCollider)
    {
        Vector3 positionToLook = new Vector3(_movement.GetMeshStatus.positionToLook.x, transform.position.y, _movement.GetMeshStatus.positionToLook.z);
        
        switch(typeCollider)
        {
            case ResourceType.Tree: _animator.SetPicking(); transform.LookAt(positionToLook);
            break;
            case ResourceType.Mine: _animator.SetMining(); transform.LookAt(positionToLook);
            break;
            case ResourceType.None: _animator.SetIdle();
            break;
        }
    }

    public void EnableUnitMovement()
    {
        _movement.enabled = true;
    }

    public void DisableUnitMovement()
    {
        _movement.enabled = false;
    }
}

public struct ResourceTrigger
{

    public ResourceTrigger(bool status, ResourceType type)
    {
        isColliding = status;
        resourceType = type;
        positionToLook = Vector3.forward;
    }

    public bool isColliding;
    public ResourceType resourceType;
    public Vector3 positionToLook;
}

public enum ResourceType
{
    None, Mine, Tree
}
