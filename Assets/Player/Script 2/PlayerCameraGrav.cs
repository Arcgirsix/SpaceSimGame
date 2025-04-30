using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraGrav : MonoBehaviour
{
    [Header("gen param")]
    [SerializeField] private PlayerDataManager playerDataManager;

    [Header("cam param")]
    [SerializeField] private float cameraSensitivity;
    [SerializeField] float borderViewFieldDown = 90f;
    [SerializeField] float borderViewFieldUp = -90f;

    private InputSysActions inputSysActions;
    private InputAction lookAction => inputSysActions.Player.Look;
    private Vector2 moveCamDir;
    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

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
    }

    private void OnDisable()
    {
        lookAction.Disable();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {

        float mouseX = moveCamDir.x * cameraSensitivity * Time.deltaTime;
        float mouseY = moveCamDir.y * cameraSensitivity * Time.deltaTime;

        verticalRotation -= mouseY;
        horizontalRotation += mouseX;
        verticalRotation = Mathf.Clamp(verticalRotation, borderViewFieldUp, borderViewFieldDown);

        transform.rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);
    }
}
