using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 1;

    [SerializeField] GameObject explosionVFX;
    [SerializeField] float explosionVFXDuration = 1f;

    // Damage received
    public int GetDamage()
    {
        return damage;
    }

    // Destroys the object
    public void Hit()
    {
        Destroy(gameObject);

        // Instantiate explosion effects
        GameObject explosion = Instantiate(explosionVFX, transform.position, Quaternion.identity);

        // Destroy after 1 second
        Destroy(explosion, explosionVFXDuration);
    }
}
