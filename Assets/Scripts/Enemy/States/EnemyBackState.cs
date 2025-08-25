using UnityEngine;

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