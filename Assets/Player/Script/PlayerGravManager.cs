using Unity.VisualScripting;
using UnityEngine;

public class PlayerGravManager : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform playerTransform;

    private void OnValidate()
    {
        if (rb == null)
        {
            rb = GetComponentInParent<Rigidbody>();
        }

        if (playerTransform == null)
        {
            playerTransform = GetComponentInParent<Transform>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("détection");

        if (other.gameObject.tag == "InsideShip")
        {
            TurnGravity(true);
            Debug.Log("inside ship");
        }

        if (other.gameObject.tag == "OutsideShip")
        {
            TurnGravity(false);
            Debug.Log("outside ship");
        }
    }

    private void TurnGravity(bool _isGravityOn)
    {
        GetComponent<PlayerGravityMovement>().enabled = _isGravityOn;
        GetComponent<PlayerGravityCamera>().enabled = _isGravityOn;
        GetComponent<PlayerNoGravityMovement>().enabled = !_isGravityOn;
        GetComponent<PlayerNoGravityCamera>().enabled = !_isGravityOn;

        rb.useGravity = _isGravityOn;
        
        if (_isGravityOn )
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
            playerTransform.rotation = new Quaternion(0f, playerTransform.rotation.y, 0f, 0f);
        }
        if (!_isGravityOn)
        {
            rb.constraints = RigidbodyConstraints.None;
            playerTransform.rotation = new Quaternion(0f, playerTransform.rotation.y, 0f, 0f);
        }
    }
}
