using UnityEngine;

public class EnemyBackState : EnemyState
{
    IBackData data;
    public EnemyBackState(EnemyStateController stateController, CharacterController enemyMotor, EnemyConfig config) : base(stateController, enemyMotor, config)
    {
    }

    public override void SetData<T>(T data)
    {
        this.data = data as IBackData;
    }

    public override void Enter()
    {
        
    }

    public override void Execute()
    {
        Vector3 direction = CurrentDirection();
        motor.SimpleMove(config.moveSpeed * direction);

        if (data.PlayerIsInSight(motor.transform.position, direction, config.junctionDetectDistance, out bool reachJunction))
        {
            stateController.ChangeState(EnemyStateName.Chase);
        }

        Vector3 newDir = CurrentDirection();
        if (Vector3.Dot(direction, newDir) <= 0)
        {
            UpdateBackProgress();
        }
    }

    Vector3 CurrentDirection()
    {
        return data.GetDirection(data.backRoute[data.backRoute.Count - 1].transform.position, motor.transform.position);
    }

    void UpdateBackProgress()
    {
        data.backRoute.RemoveAt(data.backRoute.Count - 1);
        if (data.backRoute.Count == 0)
        {
            stateController.ChangeState(EnemyStateName.Patrol);
        }
    }

    public override void Exit()
    {

    }
}