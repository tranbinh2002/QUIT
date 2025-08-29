using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject[] routes;

    public void Constructor(JunctionData junctionData, LayerMask junctionMask)
    {
        for (int i = 0; i < routes.Length; i++)
        {
            GameObject enm = Instantiate(enemyPrefab, routes[i].GetComponentsInChildren<Transform>()[1].position, Quaternion.identity, transform);
            enm.GetComponent<EnemyProcessor>().Constructor(routes[i], junctionData, junctionMask);
        }
    }
}
