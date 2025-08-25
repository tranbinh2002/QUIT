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