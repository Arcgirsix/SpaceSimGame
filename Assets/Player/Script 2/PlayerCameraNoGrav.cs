using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraNoGrav : MonoBehaviour
{
    [Header("gen param")]
    [SerializeField] private PlayerDataManager playerDataManager;

    [Header("cam param")]
    [SerializeField] private float cameraSensitivity;

    private InputSysActions inputSysActions;
    private InputAction lookAction => inputSysActions.Player.Look;
    private InputAction rollAction => inputSysActions.NoGravity.Roll;

    private float rollMoveDir;
    private Vector2 moveCamDir;

    private void OnValidate()
    {
        if (playerDataManager == null)
        {
            playerDataManager = GetComponentInParent<PlayerDataManager>();
        }
    }

    private void Awake()
    {
        cameraSensitivity = playerDataManager.playerSO.cameraSensitivity;

        inputSysActions = new InputSysActions();

        inputSysActions.Player.Look.performed += Look_performed;
        inputSysActions.Player.Look.canceled += Look_canceled;

        inputSysActions.NoGravity.Roll.performed += Roll_performed;
        inputSysActions.NoGravity.Roll.canceled += Roll_canceled;
    }

    private void Roll_canceled(InputAction.CallbackContext obj)
    {
        rollMoveDir = rollAction.ReadValue<float>();
    }

    private void Roll_performed(InputAction.CallbackContext obj)
    {
        rollMoveDir = rollAction.ReadValue<float>();
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
        float mouseX = moveCamDir.x * cameraSensitivity * Time.deltaTime;
        float mouseY = -moveCamDir.y * cameraSensitivity * Time.deltaTime;
        float roll = -rollMoveDir * 5f * cameraSensitivity * Time.deltaTime;
        
        transform.Rotate(mouseY, mouseX, roll);
    }
}
