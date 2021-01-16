using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // Time delay between each scene change
    [SerializeField] float delay = 1.5f;

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadStartMenu()
    {
        // Loads the first scene
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        // Loads the 2DCarGame scene
        SceneManager.LoadScene("2DCarGame");
    }

    public void LoadGameOver()
    {
        // Loads the GameOver scene after 1.5 seconds
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame()
    {
        // Only works in .exe file
        Application.Quit();
    }
}
