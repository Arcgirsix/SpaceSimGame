using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerNoGravityCamera : MonoBehaviour
{
    /*[Header("gen param")]
    [SerializeField] private PlayerDataManager playerDataManager;
    [SerializeField] private Transform playerHeadPivot;

    [Header("cam param")]
    [SerializeField] private float cameraSensitivity;

    private InputSystem_Actions inputSystem_Actions;
    private InputAction lookAction => inputSystem_Actions.PlayerGravity.Look;
    private InputAction rollAction => inputSystem_Actions.PlayerNoGravity.Roll;

    public float moveRollDir;
    private Vector2 moveCamDir;
    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;
    private float zRotation = 0f;

    private void OnValidate()
    {

        if (playerDataManager == null)
        {
            playerDataManager = GetComponent<PlayerDataManager>();
        }
        if (playerHeadPivot == null)
        {
            playerHeadPivot = GetComponentInParent<Transform>();
        }

    }

    private void Awake()
    {
        cameraSensitivity = playerDataManager.playerSO.cameraSensitivity;

        inputSystem_Actions = new InputSystem_Actions();

        inputSystem_Actions.PlayerNoGravity.Look.performed += Look_performed;
        inputSystem_Actions.PlayerNoGravity.Look.canceled += Look_canceled;

        inputSystem_Actions.PlayerNoGravity.Roll.performed += Roll_performed; ;
        inputSystem_Actions.PlayerNoGravity.Roll.canceled += Roll_canceled;
    }

    private void Roll_performed(InputAction.CallbackContext obj)
    {
        moveRollDir = rollAction.ReadValue<float>();
    }

    private void Roll_canceled(InputAction.CallbackContext obj)
    {
        moveRollDir = rollAction.ReadValue<float>();
    }

    private void Look_canceled(InputAction.CallbackContext obj)
    {
        moveCamDir = lookAction.ReadValue<Vector2>();
    }

    private void Look_performed(InputAction.CallbackContext obj)
    {
        moveCamDir = lookAction.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        lookAction.Enable();
        rollAction.Enable();
    }

    private void OnDisable()
    {
        lookAction.Disable();
        rollAction.Disable();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        moveCamDir = lookAction.ReadValue<Vector2>();
        float mouseX = moveCamDir.x * cameraSensitivity * Time.deltaTime;
        float mouseY = moveCamDir.y * cameraSensitivity * Time.deltaTime;
        float roll = moveRollDir * cameraSensitivity * Time.deltaTime;


        verticalRotation -= mouseY;
        horizontalRotation += mouseX;
        zRotation -= roll;

        playerHeadPivot.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, zRotation);
    }*/
}
