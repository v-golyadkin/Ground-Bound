using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    [SerializeField] private Animator _fadeScreenAnimator;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }


    public void LoadLevel(Level level)
    {
        StartCoroutine(LoadLevelRoutine(level.sceneName));
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadLevelRoutine(levelName));
    }

    private IEnumerator LoadLevelRoutine(string name)
    {
        if (!_fadeScreenAnimator.gameObject.activeSelf)
        {
            _fadeScreenAnimator.gameObject.SetActive(true);
        }
        
        _fadeScreenAnimator.SetTrigger("fade");

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(name);
        
        _fadeScreenAnimator.SetTrigger("unFade");
        //_fadeScreenAnimator.gameObject.SetActive(false);
    }
}
