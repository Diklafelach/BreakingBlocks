using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    GameState gameState;
    private void Start()
    {
        gameState = FindObjectOfType<GameState>();

    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(SceneManager.sceneCountInBuildSettings == currentSceneIndex+2)
        {
            gameState.StopTimer();
        }
        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void LoadStartScene()
    {
        gameState.ResetGame();
        SceneManager.LoadScene("Start Menu");

    }
  
    public void QuitGame()
    {
        Application.Quit();
    }


}