using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Obstacle Shotting
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.5f;
    [SerializeField] float maxTimeBetweenShots = 4f;

    [SerializeField] GameObject bulletObstaclePrefab;
    [SerializeField] float bulletObstacleSpeed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        // Generates a random number between minTimeBetweenShots and maxTimeBetweenShots
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    // Counts down the time between shots and shoots a bullet
    private void CountDownAndShoot()
    {
        // For every frame reduces the amount of time to shot/run
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            ObstacleFire();
            // Reset shotCounter after every fire
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void ObstacleFire()
    {
        // Spawn an obstacleBullet at Obstacle position
        GameObject obstacleBullet = Instantiate(bulletObstaclePrefab, transform.position, Quaternion.identity) as GameObject;

        // Rotating the obstacleBullet so it faces the player direction
        obstacleBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180));

        // Obstacle bullet shoots downwards, hence, -bulletObstacleSpeed
        obstacleBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletObstacleSpeed);
    }
}
