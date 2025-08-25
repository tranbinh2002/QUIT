using UnityEngine;

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
        //KHONG xoa danh sach duong ve
    }
}
