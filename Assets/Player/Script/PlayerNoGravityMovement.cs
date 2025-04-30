using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerNoGravityMovement : MonoBehaviour
{
    /*[SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;
    private Vector3 moveDir;
    private Vector3 playerVel;

    [SerializeField] private PlayerDataManager playerDataManager;

    [SerializeField] private Transform playerHeadPivot;

    private InputSystem_Actions inputSystem_Actions;
    private InputAction moveAction => inputSystem_Actions.PlayerNoGravity.Move;

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

        if (playerHeadPivot == null)
        {
            playerHeadPivot = GetComponentInParent<Transform>();
        }
    }

    private void Awake()
    {
        moveSpeed = playerDataManager.playerSO.gravMoveSpeed;
        sprintSpeed = playerDataManager.playerSO.gravSprintSpeed;

        inputSystem_Actions = new InputSystem_Actions();

        inputSystem_Actions.PlayerNoGravity.Move.performed += Move_performed;
        inputSystem_Actions.PlayerNoGravity.Move.canceled += Move_canceled;
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
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void FixedUpdate()
    {
    
        playerVel = new Vector3(moveDir.x * moveSpeed, moveDir.y * moveSpeed, moveDir.z * moveSpeed );
        rb.linearVelocity = playerHeadPivot.TransformDirection(playerVel);
    }*/
}
