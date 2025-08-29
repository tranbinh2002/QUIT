using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField]
    PlayerConfig playerConfig;
    
    LayerMask junctionMask;

    IHaveMoveDirection motor;
    JunctionData junctionData;
    public void Constructor(JunctionData junctionData, LayerMask junctionMask)
    {
        this.junctionData = junctionData;
        this.junctionMask = junctionMask;
    }

    void Start()
    {
        motor = GetComponent<IHaveMoveDirection>();
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, motor.direction, out RaycastHit hit, playerConfig.junctionDetectDistance, junctionMask, QueryTriggerInteraction.Collide))
        {
            junctionData.containPlayerJunction = hit.collider;
        }
    }
}
