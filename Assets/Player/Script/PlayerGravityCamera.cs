using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGravityCamera : MonoBehaviour
{
    [Header("gen param")]
    [SerializeField] private PlayerDataManager playerDataManager;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform playerHeadPivot;

    [Header("cam param")]
    [SerializeField] private float cameraSensitivity;
    [SerializeField] float borderViewFieldDown = 90f;
    [SerializeField] float borderViewFieldUp = -90f;

    private InputSystem_Actions inputSystem_Actions;
    private InputAction lookAction => inputSystem_Actions.PlayerGravity.Look;

    private Vector2 moveCamDir;
    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    private void OnValidate()
    {

        if (playerDataManager == null)
        {
            playerDataManager = GetComponent<PlayerDataManager>();
        }

        if (playerCamera == null)
        {
            playerCamera = GetComponentInChildren<Camera>();
        }

        if (cameraTransform == null)
        {
            cameraTransform = playerCamera.transform;
        }
    }

    private void Awake()
    {
        cameraSensitivity = playerDataManager.playerSO.cameraSensitivity;

        inputSystem_Actions = new InputSystem_Actions();

        inputSystem_Actions.PlayerGravity.Look.performed += Look_performed;
        inputSystem_Actions.PlayerGravity.Look.canceled += Look_canceled;
    }

    private void Look_canceled(InputAction.CallbackContext obj)
    {
        moveCamDir = lookAction.ReadValue<Vector2>();
        //throw new System.NotImplementedException();
    }

    private void Look_performed(InputAction.CallbackContext obj)
    {
        moveCamDir = lookAction.ReadValue<Vector2>();
        //throw new System.NotImplementedException();
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

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        playerHeadPivot.localRotation = Quaternion.Euler(0f, horizontalRotation, 0f);
    }
}
