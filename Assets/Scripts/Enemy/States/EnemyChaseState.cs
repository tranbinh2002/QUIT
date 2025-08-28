using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    IChaseData data;
    HashSet<Collider> trackColliderOnRoute;
    public EnemyChaseState(EnemyStateController stateController, CharacterController enemyMotor, EnemyConfig config) : base(stateController, enemyMotor, config)
    {
        trackColliderOnRoute = new HashSet<Collider>();
    }

    public override void SetData<T>(T data)
    {
        this.data = data as IChaseData;
    }

    public override void Enter()
    {
        TrackRoute();
    }
    
    void TrackRoute()
    {
        data.trackChaseRoute.Add(data.junctionData.containPlayerJunction);
        trackColliderOnRoute.Add(data.junctionData.containPlayerJunction);
    }

    public override void Execute()
    {
        Vector3 moveDirection = data.GetDirection(data.trackChaseRoute[data.trackChaseRoute.Count - 1].transform.position, motor.transform.position);
        if (data.PlayerIsInSight(motor.transform.position, moveDirection, config.junctionDetectDistance, out bool reachJunction))
        {
            motor.SimpleMove(config.runSpeed * moveDirection);
            TrackRouteOnChasing();
        }
        else if (reachJunction)
        {
            stateController.ChangeState(EnemyStateName.Back);
        }
    }

    void TrackRouteOnChasing()
    {
        if (trackColliderOnRoute.Contains(data.junctionData.containPlayerJunction))
        {
            RemoveRedundancy();
        }
        else
        {
            TrackRoute();
        }
    }
    void RemoveRedundancy()
    {
        for (int i = data.trackChaseRoute.Count - 1; i >= 0; i--)
        {
            if (data.trackChaseRoute[i] == data.junctionData.containPlayerJunction)
            {
                return;
            }
            data.trackChaseRoute.RemoveAt(i);
        }
    }

    public override void Exit()
    {
        //loại bỏ phần tử cuối vì đang ở vị trí này rồi
        data.trackChaseRoute.RemoveAt(data.trackChaseRoute.Count - 1);
        trackColliderOnRoute.Clear();
    }
}
