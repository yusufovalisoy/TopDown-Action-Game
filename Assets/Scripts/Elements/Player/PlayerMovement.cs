using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask groundMask;

    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public float jumpHeight = 1.5f;
    public float gravity = -20f;
    public float rotationSpeed = 15f;

    private CharacterController controller;
    private Animator animator;
    private Vector3 velocity;

    public bool IsMoving { get; private set; }
    public bool IsRunning { get; private set; }
    public bool canMove = true;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(!canMove)
        {
            if (animator != null)
            {
                animator.SetFloat("Speed", 0f);
                animator.SetBool("Aiming", false);
            }
            return;
        }
        HandleRotationToMouse();
        HandleMovement();
        HandleJumpAndGravity();
        UpdateAnimatorStates();
    }

    void HandleRotationToMouse()
    {
        if (mainCamera == null) return;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 500f, groundMask))
        {
            Vector3 lookPoint = hit.point;
            lookPoint.y = transform.position.y;

            Vector3 direction = lookPoint - transform.position;

            if (direction.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
            }
        }
    }

    void HandleMovement()
    {
        float x = 0f;
        float z = 0f;

        if (Input.GetKey(KeyCode.W)) z += 1f;
        if (Input.GetKey(KeyCode.S)) z -= 1f;
        if (Input.GetKey(KeyCode.A)) x -= 1f;
        if (Input.GetKey(KeyCode.D)) x += 1f;

        Vector3 input = new Vector3(x, 0f, z).normalized;

        IsMoving = input != Vector3.zero;
        //IsRunning = IsMoving && Input.GetKey(KeyCode.LeftShift);

        float currentSpeed = IsRunning ? runSpeed : walkSpeed;
        controller.Move(input * currentSpeed * Time.deltaTime);
    }

    void HandleJumpAndGravity()
    {
        if (controller.isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            if (animator != null)
            {
                animator.SetTrigger("Jump");
            }
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void UpdateAnimatorStates()
    {
        if (animator == null) return;

        float speedValue = 0f;

        if (IsMoving)
        {
            speedValue = IsRunning ? 1f : 0.5f;
        }

        animator.SetFloat("Speed", speedValue);
        animator.SetBool("Aiming", IsMoving);
    }
}