using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    [SerializeField] private List<Transform> _roomPoints;
    [SerializeField] private int _pointsPerCurve = 50;
    [SerializeField] private GameObject _miniPointPrefab; 

    public List<Vector3> GeneratePoints()
    {
        List<Vector3> points = new List<Vector3>();

        for (int i = 0; i < _roomPoints.Count - 1; i += 3)
        {
            Vector3 P0 = _roomPoints[i].position;
            Vector3 P1 = _roomPoints[Mathf.Min(i + 1, _roomPoints.Count - 1)].position;
            Vector3 P2 = _roomPoints[Mathf.Min(i + 2, _roomPoints.Count - 1)].position;
            Vector3 P3 = _roomPoints[Mathf.Min(i + 3, _roomPoints.Count - 1)].position;

            for (int j = 0; j <= _pointsPerCurve; j++)
            {
                float t = j / (float)_pointsPerCurve;
                Vector3 point = GetBezierPoint(P0, P1, P2, P3, t);

                if (_miniPointPrefab != null)
                {
                    GameObject temp = Instantiate(_miniPointPrefab, point, Quaternion.identity);
                    temp.transform.SetParent(this.transform);
                    temp.name = $"Point: {i} + {j}";
                }

                points.Add(point);
            }
        }

        return points;
    }

    private Vector3 GetBezierPoint(Vector3 P0, Vector3 P1, Vector3 P2, Vector3 P3, float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 point = uuu * P0;
        point += 3 * uu * t * P1;
        point += 3 * u * tt * P2;
        point += ttt * P3;

        return point;
    }

    public int PointsPerCurve => _pointsPerCurve;
}