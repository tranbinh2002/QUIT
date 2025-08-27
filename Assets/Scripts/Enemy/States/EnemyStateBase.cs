using UnityEngine;

public abstract class EnemyState
{
    protected EnemyStateController stateController;
    protected CharacterController motor;

    protected EnemyConfig config;
    public EnemyState(EnemyStateController stateController, CharacterController enemyMotor, EnemyConfig config)
    {
        this.stateController = stateController;
        motor = enemyMotor;
        this.config = config;
    }
    public abstract void SetData<T>(T data);
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}