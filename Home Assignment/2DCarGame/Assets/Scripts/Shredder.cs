using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] int scoreValue = 5;

    [SerializeField] AudioClip pointGainSound;
    [SerializeField] [Range(0, 1)] float pointGainSoundVolume = 0.15f;

    // Destroy missile on collision with Shredder game object
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        // Adding score points to obstacles that have a tag "Obstacle"
        // Manually added from the Tag and Layer Manager
        if (otherObject.gameObject.CompareTag("Obstacle"))
        {
            // Adds score to GameSession Score
            FindObjectOfType<GameSession>().AddToScore(scoreValue);

            AudioSource.PlayClipAtPoint(pointGainSound, Camera.main.transform.position, pointGainSoundVolume);

            Destroy(otherObject.gameObject);
        } else // If an object without the tag collides with the shredder don't add score
        {
            Destroy(otherObject.gameObject);
        }
    }
}
