using UnityEngine;

public class EnemyPatrolState : EnemyState
{
    IPatrolData data;
    public EnemyPatrolState(EnemyStateController stateController, CharacterController enemyMotor, EnemyConfig config) : base(stateController, enemyMotor, config)
    {
    }

    public override void SetData<T>(T data)
    {
        this.data = data as IPatrolData;
    }

    Vector3 currentDirection;
    Vector3 currentVelocity;
    public override void Enter()
    {
        UpdateCurrentVelocity();
    }

    void UpdateCurrentVelocity()
    {
        currentDirection = CurrentDirection();
        currentVelocity = config.moveSpeed * currentDirection;
    }
    Vector3 CurrentDirection()
    {
        return data.GetDirection(data.patrolRoute[data.currentPositionIndex], motor.transform.position);
    }

    public override void Execute()
    {
        motor.SimpleMove(currentVelocity);

        if (data.PlayerIsInSight(motor.transform.position, currentDirection, config.junctionDetectDistance, out bool reachJunction))
        {
            stateController.ChangeState(EnemyStateName.Chase);
        }

        Vector3 newDir = CurrentDirection();
        if (Vector3.Dot(newDir, currentDirection) <= 0)
        {
            SetNextPositionIndex();
            UpdateCurrentVelocity();
        }

    }

    bool forwardIterating = true;
    public void SetNextPositionIndex()
    {
        if (forwardIterating && data.currentPositionIndex == data.patrolRoute.Length - 1)
        {
            forwardIterating = false;
        }
        if (!forwardIterating && data.currentPositionIndex == 0)
        {
            forwardIterating = true;
        }

        if (forwardIterating)
        {
            data.currentPositionIndex++;
        }
        else
        {
            data.currentPositionIndex--;
        }
    }

    public override void Exit()
    {

    }
}
