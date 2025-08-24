using System;
using UnityEngine;

public class JunctionProcessor : MonoBehaviour //CODE BẨN
{
    public Action<Vector3> enemySeePlayer;

    [SerializeField]
    Transform player;
    [SerializeField]
    Transform[] enemies;

    [SerializeField]
    LayerMask playerMask;
    [SerializeField]
    LayerMask enemyMask;
    float detectDistance;

    [SerializeField]
    JunctionProcessor[] watchJunctions;
    [SerializeField]
    GameObject junctionParent;
    JunctionProcessor[] otherJunctions;

    void Start()
    {
        JunctionProcessor[] allJunctions = junctionParent.GetComponentsInChildren<JunctionProcessor>();
        otherJunctions = new JunctionProcessor[allJunctions.Length - 1];
        int index = 0;
        for (int i = 0; i < allJunctions.Length; i++)
        {
            if (allJunctions[i] == this)
            {
                continue;
            }
            otherJunctions[index] = allJunctions[i];
            index++;
        }
    }

    bool containPlayer;
    bool[] containEnemies;

    void Update()
    {
        CheckPlayer();
        for (int i = 0; i < enemies.Length; i++)
        {
            CheckEnemy(i);
        }
    }

    void CheckPlayer()
    {
        Ray ray = new Ray(transform.position, player.position - transform.position);
        if (Physics.Raycast(ray, detectDistance, playerMask))
        {
            containPlayer = true;
            for (int i = 0; i < otherJunctions.Length; i++)
            {
                otherJunctions[i].containPlayer = false;
            }
        }
    }

    void CheckEnemy(int enemyIndex)
    {
        Ray ray = new Ray(transform.position, enemies[enemyIndex].position - transform.position);
        if (Physics.Raycast(ray, detectDistance, enemyMask))
        {
            containEnemies[enemyIndex] = true;
            for (int i = 0; i < otherJunctions.Length; i++)
            {
                otherJunctions[i].containEnemies[enemyIndex] = false;
            }
            CheckSight();
        }
    }

    void CheckSight()
    {
        if (containPlayer)
        {
            Vector3 target = player.position;
            target.y = 0;
            enemySeePlayer.Invoke(target);
            return;
        }

        for (int i = 0; i < watchJunctions.Length; i++)
        {
            if (watchJunctions[i].containPlayer)
            {
                Vector3 target = watchJunctions[i].transform.position;
                target.y = 0;
                enemySeePlayer.Invoke(target);
                return;
            }
        }
    }

}