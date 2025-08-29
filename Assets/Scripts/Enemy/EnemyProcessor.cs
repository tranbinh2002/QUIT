using UnityEngine;

public class EnemyProcessor : MonoBehaviour
{
    [SerializeField]
    EnemyConfig enemyConfig;

    [SerializeField]
    CharacterController motor;

    EnemyStateController stateController;

    public void Constructor(GameObject patrolRoute, JunctionData junctionData, LayerMask junctionMask)
    {
        stateController = new EnemyStateController(EnemyStateName.Patrol, enemyConfig, motor,
            new EnemyStateData(patrolRoute, junctionData, junctionMask));
    }

    void Update()
    {
        stateController.ExecuteCurrentState();
    }

}
