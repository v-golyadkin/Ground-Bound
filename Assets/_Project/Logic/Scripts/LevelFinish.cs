using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class LevelFinish : MonoBehaviour
{
    [SerializeField] private Level _nextLevel;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneLoader.Instance.LoadLevel(_nextLevel);
    }
}
