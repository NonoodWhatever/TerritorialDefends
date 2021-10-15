using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Credit to thfm
public class Tango : MonoBehaviour
{
    public float health;
    [SerializeField]
    GameObject deathEffect;
    void Update()
    {
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    /// 'Hits' the target for a certain amount of damage
    public void Hit(float damage)
    {
        health -= damage;
    }
}
