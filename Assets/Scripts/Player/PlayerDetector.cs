using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField]
    LayerMask junctionMask;

    IHaveMoveDirection motor;
    JunctionData junctionData;
    float junctionDetectDistance;
    public void Constructor(JunctionData junctionData, float junctionDetectDistance)
    {
        this.junctionData = junctionData;
        this.junctionDetectDistance = junctionDetectDistance;
    }

    void Start()
    {
        motor = GetComponent<IHaveMoveDirection>();
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, motor.direction, out RaycastHit hit, junctionDetectDistance, junctionMask, QueryTriggerInteraction.Collide))
        {
            junctionData.containPlayerJunction = hit.collider;
        }
    }
}
