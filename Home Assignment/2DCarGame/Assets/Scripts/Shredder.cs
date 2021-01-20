using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] int scoreValue = 5;

    [SerializeField] AudioClip pointGainSound;
    [SerializeField] [Range(0, 1)] float pointGainSoundVolume = 0.15f;

    // Destroys missile on collision with Shredder game object
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        // If an object with the tag "Obstacle" hits collides with the shredder, add score
        // Assigned from the Tag and Layer Manager of each obstacle
        if (otherObject.gameObject.CompareTag("Obstacle"))
        {
            // Adds score to GameSession Score
            FindObjectOfType<GameSession>().AddToScore(scoreValue);

            // Plays Point Gain SFX
            AudioSource.PlayClipAtPoint(pointGainSound, Camera.main.transform.position, pointGainSoundVolume);

            Destroy(otherObject.gameObject);
        } else // If an object without the tag collides with the shredder don't add score
        {
            Destroy(otherObject.gameObject);
        }
    }
}
