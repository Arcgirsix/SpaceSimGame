using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementNoGravity : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;
    private Vector3 moveDir;
    private Vector3 playerVel;
    [SerializeField] private Collider bodyCollider;


    [SerializeField] private PlayerDataManager playerDataManager;

    private InputSysActions inputSysActions;
    private InputAction moveAction => inputSysActions.NoGravity.Move;
    private InputAction stabilizeAction => inputSysActions.NoGravity.Stabilize;

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

        stabilizeAction.performed += StabilizeAction_performed;
    }

    private void StabilizeAction_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("aaaaaaaaaaaaaaaa");
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        moveDir = moveAction.ReadValue<Vector3>();
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        moveDir = moveAction.ReadValue<Vector3>();
    }

    private void OnEnable()
    {
        moveAction.Enable();
        stabilizeAction.Enable();
        bodyCollider.enabled = false;
        rb.useGravity = false;
    }

    private void OnDisable()
    {
        moveAction.Disable();
        stabilizeAction.Disable();
        bodyCollider.enabled = true;
    }

    private void FixedUpdate()
    {
        playerVel = new Vector3(moveDir.x * moveSpeed, moveDir.y * moveSpeed, moveDir.z * moveSpeed);
        rb.AddRelativeForce(playerVel);
    }
}
