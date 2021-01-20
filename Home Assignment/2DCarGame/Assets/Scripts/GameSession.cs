using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;

    // To make sure that only 1 GameSession is running
    void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        // If there is more than 1 GameSession, delete the last one created
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            // Protect the GameSession with DontDestroyOnLoad when changing scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    // Gets the value of the score
    public int GetScore()
    {
        return score;
    }

    // Add scoreValue to score
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    // Destroys gameObject after each new load
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
