using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartButtonClick()
    {
        AudioManager.Instance.PlaySFX("ui_click");

        SceneManager.LoadScene("Level_1");
    }
}
