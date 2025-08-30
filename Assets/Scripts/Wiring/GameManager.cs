using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    PlayerDetector playerDetector;
    [SerializeField]
    EnemyManager enemyManager;
    [SerializeField]
    GameObject junctionParent;
    JunctionDetector[] junctionDetectors;
    [SerializeField]
    LayerMask junctionMask;

    JunctionData junctionData;

    void Start()
    {
        junctionData = new JunctionData();
        playerDetector.Constructor(junctionData, junctionMask);
        enemyManager.Constructor(junctionData, junctionMask);
        junctionDetectors = junctionParent.GetComponentsInChildren<JunctionDetector>();
        for (int i = 0; i < junctionDetectors.Length; i++)
        {
            junctionDetectors[i].Constructor(junctionData);
        }
    }

}
