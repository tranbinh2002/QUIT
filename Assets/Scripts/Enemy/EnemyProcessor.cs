using UnityEngine;

public class EnemyProcessor : MonoBehaviour
{
    [SerializeField]
    CharacterController motor;

    EnemyStateController stateController;

    void Start()
    {
        stateController = new EnemyStateController(EnemyStateName.Patrol, motor);
    }

    void Update()
    {
        stateController.ExecuteCurrentState();    
    }

}
