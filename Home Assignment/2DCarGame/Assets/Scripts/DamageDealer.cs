using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Default damage value, but each obstacle has a unique damage value
    [SerializeField] int damage = 1;

    // Explosion particles for when the gameObject gets destroyed
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
