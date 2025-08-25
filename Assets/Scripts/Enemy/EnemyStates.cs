using UnityEngine;

public abstract class EnemyState
{
    protected EnemyStateController stateController;
    protected CharacterController motor;

    public EnemyState(EnemyStateController stateController, CharacterController enemyMotor)
    {
        this.stateController = stateController;
        motor = enemyMotor;
    }
    public abstract void SetData<T>(T data);
    public abstract void SetConfig<T>(T config);
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}

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
        //di chuyển -> chase
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

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(EnemyStateController stateController, CharacterController enemyMotor) : base(stateController, enemyMotor)
    {
    }

    public override void SetData<T>(T data)
    {
        throw new System.NotImplementedException();
    }

    public override void SetConfig<T>(T config)
    {
        throw new System.NotImplementedException();
    }

    public override void Enter()
    {
        //ghi lai diem bat dau
    }

    public override void Execute()
    {
        //raycasts, ghi lai duong ve -> patrol
    }

    public override void Exit()
    {
        //xoa danh sach duong ve
    }
}

public class EnemyBackState : EnemyState
{
    public EnemyBackState(EnemyStateController stateController, CharacterController enemyMotor) : base(stateController, enemyMotor)
    {
    }

    public override void SetData<T>(T data)
    {
        throw new System.NotImplementedException();
    }

    public override void SetConfig<T>(T config)
    {
        throw new System.NotImplementedException();
    }

    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        //patrol hoac game over
    }
}