using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] AudioClip Lose;
    GameState gameState;
    private void Start()
    {
        gameState = FindObjectOfType<GameState>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(Lose, Camera.main.transform.position);
        SceneManager.LoadScene("End Game");
        gameState.StopTimer();
    }



}
