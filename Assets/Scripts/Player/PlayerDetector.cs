using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField]
    LayerMask junctionMask;

    IHaveMoveDirection motor;
    JunctionData junction;
    float junctionDetectDistance;
    public void Constructor(JunctionData junctionData, float junctionDetectDistance)
    {
        junction = junctionData;
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
            junction.containPlayerJunction = hit.collider;
        }
    }
}
