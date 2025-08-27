using System;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerDetectable
{
    bool PlayerIsInSight(Vector3 origin, Vector3 direction, float maxDistance, out bool reachJunction);
}

public interface IPatrolData : IPlayerDetectable
{
    Vector3[] patrolRoute { get; }
    int currentPositionIndex { get; set; }
}

public interface IChaseData : IPlayerDetectable
{
    JunctionData junctionData { get; }
    List<Collider> trackChaseRoute { get; }
}

public class EnemyData : IPatrolData, IChaseData
{
    Vector3[] patrolPositions;
    LayerMask junctionMask;

    JunctionData _junctionData;
    List<Collider> trackChasePoints;

    public EnemyData(GameObject patrolRoute, JunctionData junctionData, LayerMask junctionMask)
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
        patrolPositions = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            patrolPositions[i] = points[i].position;
        }
    }

}
