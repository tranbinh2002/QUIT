using UnityEngine;

public interface IPatrolData
{
    Vector3[] patrolRoute { get; }
    int currentPositionIndex { get; set; }
}

public class EnemyData
{
    Vector3[] patrolPositions;

    public EnemyData(GameObject route)
    {
        TakePointsOnRoute(route);
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
