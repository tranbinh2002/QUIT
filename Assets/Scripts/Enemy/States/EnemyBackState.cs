using UnityEngine;

public class EnemyBackState : EnemyState
{
    public EnemyBackState(EnemyStateController stateController, CharacterController enemyMotor, EnemyConfig config) : base(stateController, enemyMotor, config)
    {
    }

    public override void SetData<T>(T data)
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
        //XOA DANH SACH TRACK
    }
}