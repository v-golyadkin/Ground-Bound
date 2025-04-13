using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private Level _currentLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);

            SceneLoader.Instance.LoadLevel(_currentLevel);
        }
    }
}
