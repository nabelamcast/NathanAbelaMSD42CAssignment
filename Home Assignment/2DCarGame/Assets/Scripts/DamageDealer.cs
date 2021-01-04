﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 1;

    // Damage received
    public int GetDamage()
    {
        return damage;
    }

    // Destroys the object
    public void Hit()
    {
        Destroy(gameObject);
    }
}
