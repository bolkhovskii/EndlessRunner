using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class StartApplication : MonoBehaviour
{
    void Start() { }
    void Update() { }

    public void LoadOnClick()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }


    public void Quit() {
        //Application.Quit();
        EditorApplication.isPlaying = false;
    }

    public void ExitScene() {
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);

    }

    public void RestartScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);

    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);

    }
}
