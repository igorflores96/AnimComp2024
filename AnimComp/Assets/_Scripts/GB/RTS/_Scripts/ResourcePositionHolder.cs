using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePositionHolder : MonoBehaviour
{
    [SerializeField] List<Transform> positionsToStay = new List<Transform>();

    private Dictionary<Transform, bool> positionsStatus = new Dictionary<Transform, bool>();

    private void OnEnable() 
    {
        foreach (Transform t in positionsToStay)
            positionsStatus.Add(t, false);
    }

    public Vector3 GrabOnePosition()
    {
        Vector3 positionToGo = Vector3.zero;

        for(int i = 0; i < positionsStatus.Count; i++)
        {
            if(positionsStatus[positionsToStay[i]] == false)
            {
                positionToGo = positionsToStay[i].position;
                positionsStatus[positionsToStay[i]] = true;
                break;
            }
        }

        return positionToGo;
    }
}
