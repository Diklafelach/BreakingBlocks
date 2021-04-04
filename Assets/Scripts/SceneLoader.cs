using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    GameState gameState;
    public int currentSceneIndex;
    static int countScene;

   
    private void Start()
    {
        gameState = FindObjectOfType<GameState>();

    }

    public void LoadNextScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //check if we in the last scene
        if (SceneManager.sceneCountInBuildSettings == currentSceneIndex + 2)
        {
            gameState.StopTimer();
        }
        countScene++;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }
    public void LoadStartScene()
    {
        gameState.ResetGame();
        countScene = 0;
        SceneManager.LoadScene("Start Menu");

    }
    public int CountScenes()
    {
        return countScene;
    }
    public void QuitGame()
    {
        Application.Quit();
    }


}