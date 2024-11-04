using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private float _rotatioSpeed;

    private void Update() 
    {

        transform.Rotate(transform.rotation.x, _rotatioSpeed, transform.rotation.z);
    }
}
