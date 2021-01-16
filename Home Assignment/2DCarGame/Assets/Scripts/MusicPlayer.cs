using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
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
            DontDestroyOnLoad(gameObject);
        }
    }
}
