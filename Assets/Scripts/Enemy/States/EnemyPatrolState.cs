using UnityEngine;

public class EnemyPatrolState : EnemyState
{
    IPatrolData data;
    EnemyConfig config;
    public EnemyPatrolState(EnemyStateController stateController, CharacterController enemyMotor) : base(stateController, enemyMotor)
    {
    }

    public override void SetData<T>(T data)
    {
        this.data = data as IPatrolData;
    }

    public override void SetConfig<T>(T config)
    {
        this.config = config as EnemyConfig;
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
        Vector3 result = Vector3.Normalize(data.patrolRoute[data.currentPositionIndex] - motor.transform.position);
        result.y = 0;
        return result;
    }

    public override void Execute()
    {
        motor.SimpleMove(currentVelocity);
        Vector3 newDir = CurrentDirection();
        if (Vector3.Dot(newDir, currentDirection) < 0)
        {
            SetNextPositionIndex();
            UpdateCurrentVelocity();
        }

        if (Physics.Raycast(data.patroller.position, currentDirection, out RaycastHit hit, config.junctionDetectDistance, data.junctionMask, QueryTriggerInteraction.Collide))
        {
            if (JunctionDetectorLocator.Instance.GetJunctionDetector(hit.collider).PlayerIsInSight())
            {
                stateController.ChangeState(EnemyStateName.Chase);
            }
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
