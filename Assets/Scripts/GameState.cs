using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameState : MonoBehaviour
{
    //config paramters
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField]public Text timerText;

    //state paramters
    [SerializeField] int currentScore=0;
    [SerializeField] Text displayText;
    [SerializeField] public bool finished=false;
    [SerializeField] bool autoPlayed = false;
    public string seconds;
    public string minutes;
    public float startTime;
    SceneLoader mysceneLoader;
    private void Awake()
    {
        int gameStatesCount = FindObjectsOfType<GameState>().Length;
        if (gameStatesCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
          
    }

    public bool IsAutoPlayEnabled()
    {
        return autoPlayed;
    }

    private void Start()
    {
        mysceneLoader = FindObjectOfType<SceneLoader>();
        displayText.text = currentScore.ToString();
        startTime = Time.time;
    }
    private void Update()
    {

        if (finished == true)
        {
            timerText.text = minutes + ":" + seconds;
            return;
        }
        else
        {
            float t = Time.time - startTime;
             minutes = ((int)t / 60).ToString();
             seconds = (t % 60).ToString("f2");
             timerText.text = minutes + ":" + seconds;
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
            Debug.Log("someone press q");//for debugging process.
        }
    }
    public void AddToScore()
    {
        currentScore = currentScore + pointsPerBlockDestroyed;
        displayText.text = currentScore.ToString();
    }
    public void AddHalfToScore()
    {
        currentScore = currentScore + pointsPerBlockDestroyed / 2;
        displayText.text = currentScore.ToString();
    }
    public void StopTimer()
    {
        finished = true;
        timerText.text = minutes + ":" + seconds;
    }
    public void ResetGame()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}