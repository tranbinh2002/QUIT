using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController
{
    EnemyState currentState;

    Dictionary<EnemyStateName, EnemyState> enemyStates;

    public EnemyStateController(EnemyStateName firstState, EnemyConfig config, CharacterController enemyMotor, EnemyStateData enemyData)
    {
        enemyStates = new()
        {
            { EnemyStateName.Patrol, new EnemyPatrolState(this, enemyMotor, config) },
            { EnemyStateName.Chase, new EnemyChaseState(this, enemyMotor, config) },
            { EnemyStateName.Back, new EnemyBackState(this, enemyMotor, config) }
        };
        
        foreach (var state in enemyStates.Values)
        {
            state.SetData(enemyData);
        }
        
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