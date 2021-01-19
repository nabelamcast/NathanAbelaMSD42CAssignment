using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    // Updates the text in UI
    Text scoreText;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the Score Text in UI with the score
        scoreText.text = gameSession.GetScore().ToString();

        if (gameSession.GetScore() >= 100)
        {
            // Finds object of type Level in hierarchy and runs the method LoadWinnerScene()
            FindObjectOfType<Level>().LoadWinnerScene();
        }
    }
}
