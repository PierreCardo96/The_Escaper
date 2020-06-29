using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private AudioManager _audioManager;

    public void LoadLoadingScene()
    {
        PlayerUI.Instance?.UnselectPowers();
        SceneManager.LoadScene("LoadingScene");
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Loading.sceneIndex = currentSceneIndex + 1;
        if (Loading.sceneIndex == 4)
        {
            SceneManager.LoadScene("Winner");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Loading.sceneIndex = 1;
        }
        else
        {
            LoadLoadingScene();
        }
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadFirstLevel()
    {
        Time.timeScale = 1f;
        PlayerUI.Instance?.ResetHealth();
        PlayerUI.Instance?.SetAllPowersActivation(false);
        AudioManager.Instance?.Play("Background");
        Loading.sceneIndex = 1;
        LoadLoadingScene();
    }

    private void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        _audioManager = AudioManager.Instance;
        _audioManager.StopMusicsForLoading();

        string currentSceneName = scene.name;
        if (currentSceneName == "Menu" || currentSceneName == "Winner")
        {
            _audioManager.StopAllMusics();
            _audioManager.Play(currentSceneName);
        }
    }
}
