using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Level", menuName = "Scriptable Objects/Levels")]
public class Level : ScriptableObject
{
    [SerializeField] public string sceneName;
}
