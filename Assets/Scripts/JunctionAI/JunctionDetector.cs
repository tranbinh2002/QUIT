using System.Collections.Generic;
using UnityEngine;

public struct JunctionData
{
    public Collider containPlayerJunction;
}

public class JunctionDetector : MonoBehaviour
{
    [SerializeField]
    Collider[] inSightJunctions;
    HashSet<Collider> inSightJunctionSet;
    JunctionData data;

    void Start()
    {
        JunctionDetectorLocator.Instance.Register(GetComponent<Collider>(), this);

        inSightJunctionSet = new HashSet<Collider>(inSightJunctions);
    }

    public void Constructor(JunctionData junctionData)
    {
        data = junctionData;
    }

    public bool PlayerIsInSight()
    {
        return inSightJunctionSet.Contains(data.containPlayerJunction);
    }

}