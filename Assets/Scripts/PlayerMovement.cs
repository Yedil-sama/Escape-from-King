using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GroundChecker groundChecker;

    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;

    private float speed;
    public float Speed 
    {
        get => speed;
        set
        {
            if (value > GameManager.Instance.maxSpeed)
            {
                value = GameManager.Instance.maxSpeed;
            }
            speed = value;
        }
    }

    private bool isGrounded;
    private Vector3 velocity;
    private CharacterController characterController;

    public void Start()
    {
        characterController = GetComponent<CharacterController>();
        groundChecker = GetComponentInChildren<GroundChecker>();
        Speed = walkSpeed;
    }

    public void Update()
    {
        Move();
        Jump();
        ApplyGravity();
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * inputX + transform.forward * inputZ;
        characterController.Move(moveDirection * Speed * Time.deltaTime);
        //Debug.Log($"moving {moveDirection} with speed {speed}");
    }

    private void Jump()
    {
        if (groundChecker.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
