using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button restartButton;


    private void OnEnable()
    {
        HealthBarManager.OnPlayerDeath += GameOver;
    }

    private void OnDisable()
    {
        HealthBarManager.OnPlayerDeath -= GameOver;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;

    }
    void GameOver()
    {
        Time.timeScale = 0f;

        // RestartButton Actives
        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Restart button reference is not set!");
        }

    }
}
