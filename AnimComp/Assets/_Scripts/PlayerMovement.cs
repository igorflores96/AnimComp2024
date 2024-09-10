using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private int _currentPoint;
    [SerializeField] private BezierCurve _bezier;
    [SerializeField] private float _totalMovement = 1f;
    [SerializeField] private float _currentMovementTime = 0;

    private List<Vector3> _roomPoints;
    private int _controlPoints;

    private void Awake() 
    {
        _roomPoints = _bezier.GeneratePoints();
        _controlPoints = _bezier.PointsPerCurve;
    }

    private void Update() 
    {
        
        Vector3 pointPosition = _roomPoints[_currentPoint];
        float distance = Vector3.Distance(transform.position, pointPosition);
        
        if (_currentMovementTime < _totalMovement)
        {
            float normalizedProgress = _currentMovementTime / _totalMovement; // 0-1
            float easing = _curve.Evaluate(normalizedProgress);
            transform.localPosition = Vector3.Lerp(transform.localPosition, pointPosition, easing);
            transform.LookAt(pointPosition);
            _currentMovementTime += Time.deltaTime;
        }

        if(distance < 1.0f)
        {
            _currentPoint = (_currentPoint + 1) % _roomPoints.Count;
            
            if(_currentPoint % _controlPoints == 1)
            {
                _currentMovementTime = 0.0f;
                Debug.Log("Resetou");
            }
        }

        
    }
}
