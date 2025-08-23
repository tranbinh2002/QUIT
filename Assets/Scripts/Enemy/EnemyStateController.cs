using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController
{
    EnemyState currentState;

    Dictionary<EnemyStateName, EnemyState> enemyStates;

    public EnemyStateController(EnemyStateName firstState, CharacterController enemyMotor)
    {
        enemyStates = new()
        {
            { EnemyStateName.Patrol, new EnemyPatrolState(this, enemyMotor) },
            { EnemyStateName.Chase, new EnemyChaseState(this, enemyMotor) },
            { EnemyStateName.Back, new EnemyBackState(this, enemyMotor) }
        };

        currentState = enemyStates[firstState];
        currentState.Enter();
    }

    public void ExecuteCurrentState()
    {
        currentState.Execute();
    }

    public void ChangeState(EnemyStateName newState)
    {
        currentState.Exit();
        currentState = enemyStates[newState];
        currentState.Enter();
    }
}

public enum EnemyStateName
{
    Patrol,
    Chase,
    Back
}