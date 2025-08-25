using System.Collections.Generic;
using UnityEngine;

public interface IPatrolData
{
    Transform patroller { get; }
    Vector3[] patrolRoute { get; }
    int currentPositionIndex { get; set; }

    LayerMask junctionMask { get; }
}

public interface IChaseData
{
    JunctionData junctionData { get; }
    List<Vector3> trackRoute { get; }
}

public class EnemyData : IPatrolData
{
    Transform enemy;
    Vector3[] patrolPositions;
    LayerMask _junctionMask;

    public EnemyData(Transform enemy, GameObject route, LayerMask junctionMask)
    {
        this.enemy = enemy;
        TakePointsOnRoute(route);
        _junctionMask = junctionMask;
    }

    public Transform patroller => enemy;
    public Vector3[] patrolRoute => patrolPositions;
    public int currentPositionIndex { get; set; } = 0;
    public LayerMask junctionMask => _junctionMask;

    void TakePointsOnRoute(GameObject route)
    {
        Transform[] points = route.GetComponentsInChildren<Transform>();
        patrolPositions = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            patrolPositions[i] = points[i].position;
        }
    }


}
