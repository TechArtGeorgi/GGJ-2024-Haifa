using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using ScriptableObjects;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string MainGameScene;
    [SerializeField] private SoundEffectSO soundeffect;
    private void Awake()
    {
        soundeffect.Play();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(MainGameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
