using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Objects/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    [Header("general values")]
    public int hp;
    //public float heightOfCharacter
    //public float reachOfCharacter

    [Header("gravity values")]
    public float gravMoveSpeed;
    public float gravSprintSpeed;
    public float jumpHeight;

    [Header("no gravity values")]
    public float noGravMoveSpeed;
    public float noGravSprintSpeed;


}
