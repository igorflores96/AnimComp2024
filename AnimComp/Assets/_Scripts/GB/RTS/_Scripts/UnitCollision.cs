using UnityEngine;

public class UnitCollision : MonoBehaviour
{    
    private readonly string _isMiningResourceTag = "Mine";
    private readonly string _isTreeResourceTag = "Tree";
    private ResourceTrigger _typeTrigger = new ResourceTrigger(false, ResourceType.None); 

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.CompareTag(_isTreeResourceTag)) 
        {
            _typeTrigger.isColliding = true;
            _typeTrigger.resourceType = ResourceType.Tree;
        }
        else if(other.gameObject.CompareTag(_isMiningResourceTag))
        {
            _typeTrigger.isColliding = true;
            _typeTrigger.resourceType = ResourceType.Mine;  
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag(_isTreeResourceTag) || other.gameObject.CompareTag(_isMiningResourceTag)) 
        {
            _typeTrigger.isColliding = false;
            _typeTrigger.resourceType = ResourceType.None;
        }
    }

    public ResourceTrigger GetTriggerStatus => _typeTrigger;

}
