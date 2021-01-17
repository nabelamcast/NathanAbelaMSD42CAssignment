using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // SerializeField makes the variable editable from Unity
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.6f;

    [SerializeField] float health = 50f;

	// Health reduction and Obstacle Collision
    [SerializeField] AudioClip damageSound;
    [SerializeField] [Range(0, 1)] float damageSoundVolume = 0.15f;

    [SerializeField] AudioClip playerDeathSound;
    [SerializeField] [Range(0, 1)] float playerDeathSoundVolume = 0.5f;

    float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // Reduces health whenever player collides with a gameObject which has DamageDealer component
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        // Access the DamageDealer from the "otherObject" which hits the player
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        // If there is no dmgDealer in otherObject, end the method
        if (!dmgDealer) { return; }

        ProcessHit(dmgDealer);
    }

    // Whenever ProcessHit() is called, send us the DamageDealer details
    private void ProcessHit(DamageDealer dmgDealer)
    {
		// Reduce player health
        health -= dmgDealer.GetDamage();

        AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position, damageSoundVolume);

        // Destroy on obstacle collison
        dmgDealer.Hit();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        health = 0;

        // Destroy Player
        Destroy(gameObject);

        AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, playerDeathSoundVolume);

        // Finds object of type Level in hierarchy and runs the method LoadGameOver()
        FindObjectOfType<Level>().LoadGameOver();
    }

    // Setting up a border around the camera
    private void SetUpMoveBoundaries()
    {
        // Retrieving camera from Unity
        Camera gameCamera = Camera.main;

        // Minimum and Maximum position of the camera
        // xMin = 0, xMax = 1
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        // yMin = 0, yMax = 1
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Moves the Car in the x-axis
    private void Move()
    {
        // deltaX is updated with the movement in the x-axis (left and right)
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        // newXPos = current x-pos of Player + difference in X by keyboard input
        var newXPos = transform.position.x + deltaX;

        // Clamps the newXPos between xMin and xMax
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        // The x-position will be updated according to the newXPos
        // Update the position of the player
        transform.position = new Vector2(newXPos, transform.position.y);
    }
}
