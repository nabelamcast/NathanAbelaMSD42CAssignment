using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // Delay time in seconds between each scene change
    [SerializeField] float delay = 1.5f;

    // Coroutine method to wait for the given time
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadStartMenu()
    {
        // Loads the first scene (Start Menu)
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        // Loads the 2DCarGame scene
        SceneManager.LoadScene("2DCarGame");

        // Resets the GameSession from the beginning
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadWinnerScene()
    {
        // Loads the winner scene (when score >= 100)
        SceneManager.LoadScene("Winner");
    }

    public void LoadGameOver()
    {
        // Loads the GameOver scene (when player health <= 0)
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame()
    {
        // Quits the application, works only outside the editor
        Application.Quit();
    }
}
