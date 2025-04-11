using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Scriptable Objects/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] public float speed = 6f;
    [SerializeField] public float acceleration = 8f;
    [SerializeField] public float deceleration = 16f;
}
