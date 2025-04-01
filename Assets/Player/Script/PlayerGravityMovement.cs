using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerGravityMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;
    private Vector2 moveDir;
    private Vector3 playerVel;

    [SerializeField] private PlayerDataManager playerDataManager;


    private InputSystem_Actions inputSystem_Actions;
    private InputAction moveAction => inputSystem_Actions.PlayerGravity.Move;

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

        inputSystem_Actions = new InputSystem_Actions();

        inputSystem_Actions.PlayerGravity.Move.performed += Move_performed;
        inputSystem_Actions.PlayerGravity.Move.canceled += Move_canceled;
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
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void FixedUpdate()
    {
        playerVel = new Vector3(moveDir.x * moveSpeed, rb.linearVelocity.y, moveDir.y * moveSpeed);
        rb.linearVelocity = transform.TransformDirection(playerVel);
    }


}
