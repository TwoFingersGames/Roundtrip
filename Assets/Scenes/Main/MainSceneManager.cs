using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager: MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}