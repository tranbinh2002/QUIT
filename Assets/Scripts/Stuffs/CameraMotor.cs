using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    [SerializeField]
    Transform followee;

    Vector3 delta;

    void Start()
    {
        delta.x = followee.position.x - transform.position.x;
        delta.y = followee.position.y - transform.position.y;
        delta.z = followee.position.z - transform.position.z;
    }

    Vector3 currentVelocity = Vector3.zero;
    float followDelay = 0.2f;
    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, followee.position - delta, ref currentVelocity, followDelay);
    }
}
