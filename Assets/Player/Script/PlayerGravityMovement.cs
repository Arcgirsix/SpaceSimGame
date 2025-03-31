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
    private InputAction moveAction;

    private void OnValidate()
    {
        playerDataManager = GetComponent<PlayerDataManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        moveSpeed = playerDataManager.playerSO.gravMoveSpeed;
        sprintSpeed = playerDataManager.playerSO.gravSprintSpeed;

        inputSystem_Actions = new InputSystem_Actions();

    }

    private void OnEnable()
    {
        moveAction = inputSystem_Actions.Player.Move;
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction = inputSystem_Actions.Player.Move;
        moveAction.Disable();
    }

/*    private void OnMove(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>();
    }*/

    private void FixedUpdate()
    {
        moveDir = moveAction.ReadValue<Vector2>();
        playerVel = new Vector3(moveDir.x * moveSpeed, rb.linearVelocity.y, moveDir.y * moveSpeed);
        rb.linearVelocity = transform.TransformDirection(playerVel);
    }


}
