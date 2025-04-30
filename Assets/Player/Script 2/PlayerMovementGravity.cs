using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementGravity : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;
    private float usedSpeed;
    private Vector3 moveDir;
    private Vector3 playerVel;
    [SerializeField] private Collider bodyCollider;


    [SerializeField] private PlayerDataManager playerDataManager;

    private InputSysActions inputSysActions;
    private InputAction moveAction => inputSysActions.Gravity.Move;
    private InputAction sprintAction => inputSysActions.Player.Sprint;

    private void OnValidate()
    {

        if (playerDataManager == null)
        {
            playerDataManager = GetComponent<PlayerDataManager>();
        }

        if (rb == null)
        {
            rb = GetComponentInParent<Rigidbody>();
        }
    }

    private void Awake()
    {
        moveSpeed = playerDataManager.playerSO.gravMoveSpeed;
        sprintSpeed = playerDataManager.playerSO.gravSprintSpeed;

        inputSysActions = new InputSysActions();

        moveAction.performed += Move_performed;
        moveAction.canceled += Move_canceled;

        sprintAction.performed += SprintAction_performed;
        sprintAction.canceled += SprintAction_canceled;
    }

    private void SprintAction_canceled(InputAction.CallbackContext obj)
    {
        usedSpeed = moveSpeed;
    }

    private void SprintAction_performed(InputAction.CallbackContext obj)
    {
        usedSpeed = sprintSpeed;
    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        moveDir = moveAction.ReadValue<Vector2>();
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        moveDir = moveAction.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        moveAction.Enable();
        sprintAction.Enable();
        rb.useGravity = true;
    }

    private void OnDisable()
    {
        moveAction.Disable();
        sprintAction.Disable();
    }

    private void FixedUpdate()
    {
        playerVel = new Vector3(moveDir.x * usedSpeed, rb.linearVelocity.y , moveDir.y * usedSpeed);
        rb.linearVelocity = transform.TransformDirection(playerVel);
    }
}
