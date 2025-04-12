using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private Level _currentLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);

            SceneManager.LoadScene(_currentLevel.sceneName, LoadSceneMode.Single);
        }
    }
}
