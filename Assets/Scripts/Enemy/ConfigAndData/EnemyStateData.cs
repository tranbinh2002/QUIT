using System.Collections.Generic;
using UnityEngine;

public interface IPlayerDetectable
{
    bool PlayerIsInSight(Vector3 origin, Vector3 direction, float maxDistance, out bool reachJunction);
}

public interface IDirectionCalculable
{
    Vector3 GetDirection(Vector3 target, Vector3 start);
}

public interface IPatrolData : IPlayerDetectable, IDirectionCalculable
{
    Vector3[] patrolRoute { get; }
    int currentPositionIndex { get; set; }
}

public interface IChaseData : IPlayerDetectable, IDirectionCalculable
{
    JunctionData junctionData { get; }
    List<Collider> trackChaseRoute { get; }
}

public interface IBackData : IPlayerDetectable, IDirectionCalculable
{
    List<Collider> backRoute { get; }
}

public class EnemyStateData : IPatrolData, IChaseData, IBackData
{
    Vector3[] patrolPositions;
    LayerMask junctionMask;

    JunctionData _junctionData;
    List<Collider> trackChasePoints;

    public EnemyStateData(GameObject patrolRoute, JunctionData junctionData, LayerMask junctionMask)
    {
        TakePointsOnRoute(patrolRoute);
        this.junctionMask = junctionMask;

        _junctionData = junctionData;
        trackChasePoints = new List<Collider>();
    }

    public Vector3[] patrolRoute => patrolPositions;
    public int currentPositionIndex { get; set; } = 0;

    public JunctionData junctionData => _junctionData;
    public List<Collider> trackChaseRoute => trackChasePoints;

    public List<Collider> backRoute => trackChasePoints;

    public Vector3 GetDirection(Vector3 target, Vector3 start)
    {
        Vector3 result = Vector3.Normalize(target - start);
        result.y = 0;
        return result;
    }

    public bool PlayerIsInSight(Vector3 origin, Vector3 direction, float maxDistance, out bool reachJunction)
    {
        reachJunction = false;
        if (Physics.Raycast(origin, direction, out RaycastHit hit, maxDistance, junctionMask, QueryTriggerInteraction.Collide))
        {
            reachJunction = true;
            if (JunctionDetectorLocator.Instance.GetJunctionDetector(hit.collider).PlayerIsInSight())
            {
                return true;
            }
        }
        return false;
    }

    void TakePointsOnRoute(GameObject route)
    {
        Transform[] points = route.GetComponentsInChildren<Transform>();
        //loại bỏ phần tử đầu tiên là transform của parent
        patrolPositions = new Vector3[points.Length - 1];
        for (int i = 1; i < points.Length; i++)
        {
            patrolPositions[i - 1] = points[i].position;
        }
    }

}
