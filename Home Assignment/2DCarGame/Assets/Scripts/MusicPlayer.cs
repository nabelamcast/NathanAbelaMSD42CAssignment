using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // To make sure that only 1 MusicPlayer is running
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        // Retrieves type object attached to this script
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            // If there is more than 1 MusicPlayer, delete the last one created
            Destroy(gameObject);
        }
        else
        {
            // Does not destroy MusicPlayer when changing scenes
            // Keeps background music in sync with previous scene
            DontDestroyOnLoad(gameObject);
        }
    }
}
