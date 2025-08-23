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

    public EnemyPatrolState(EnemyStateController stateController, CharacterController enemyMotor) : base(stateController, enemyMotor)
    {
    }

    public override void SetData<T>(T data)
    {
        this.data = data as IPatrolData;
    }

    public override void SetConfig<T>(T config)
    {
        throw new System.NotImplementedException();
    }

    public override void Enter()
    {
        //lấy điểm đích
    }

    public override void Execute()
    {
        //di chuyển -> chase

        //motor.SimpleMove();
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