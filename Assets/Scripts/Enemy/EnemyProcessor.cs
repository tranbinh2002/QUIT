using UnityEngine;

public class EnemyProcessor : MonoBehaviour
{
    [SerializeField]
    EnemyConfig enemyConfig;

    [SerializeField]
    CharacterController motor;

    [SerializeField]
    GameObject patrolRouteParent;

    EnemyStateController stateController;

    public void Constructor(JunctionData junctionData, LayerMask junctionMask)
    {
        stateController = new EnemyStateController(EnemyStateName.Patrol, enemyConfig, motor,
            new EnemyStateData(patrolRouteParent, junctionData, junctionMask));
    }

    void Update()
    {
        stateController.ExecuteCurrentState();    
    }

}
