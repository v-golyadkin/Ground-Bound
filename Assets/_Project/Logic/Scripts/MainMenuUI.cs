using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void StartButtonClick()
    {
        AudioManager.Instance.PlaySFX("ui_click");

        gameObject.SetActive(false);

        SceneLoader.Instance.LoadLevel("Level_1");
    }
}
