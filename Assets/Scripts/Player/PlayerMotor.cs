using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    CharacterController controller;

    const float GRAVITY = 9.81f;
    bool isJumping;
    int currentJumpDirection = 1; //hướng nhảy hiện tại: nhảy lên
    float velocity = 5f;
    Vector3 currentMoveDirection;
    float jumpHeight = 0.5f;

    public void SetUp(float playerVelocity)
    {
        velocity = playerVelocity;
    }

    private void Start()
    {
        while (!controller.isGrounded)
        {
            controller.Move(-GRAVITY * Time.deltaTime * Vector3.up);
        }
    }

    void Update()
    {
        MoveHandle();
        JumpInputHandle();
    }

    void MoveHandle()
    {
        Vector3 motion;
        if (!isJumping)
        {
            motion = velocity * Time.deltaTime
            * Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            currentMoveDirection = motion;
            motion.y -= GRAVITY * Time.deltaTime;
        }
        else
        {
            motion = currentMoveDirection + JumpMotion();
        }
        controller.Move(motion);
    }

    const float safeValue = 0.005f;
    Vector3 JumpMotion()
    {
        float h = jumpHeight - transform.position.y;
        if (h < safeValue)
        {
            currentJumpDirection = -1;
        }
        return currentJumpDirection * Time.deltaTime * Mathf.Sqrt(2 * GRAVITY * Mathf.Abs(h)) * Vector3.up;
    }

    void JumpInputHandle()
    {
        if (isJumping && controller.isGrounded)
        {
            isJumping = false;
            currentJumpDirection = 1;
        }

        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }
}