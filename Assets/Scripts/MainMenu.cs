using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string MainGameScene;
    public void StartGame()
    {
        SceneManager.LoadScene(MainGameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
