using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Credit to thfm
public class Bullet : MonoBehaviour
{
    public float damage;
    public GameObject Effect;

    void OnCollisionEnter(Collision other)
    {
        Tango target = other.gameObject.GetComponent<Tango>();
        // Only attempts to inflict damage if the other game object has
        // the 'Target' component


        if (target != null)
        {
            target.Hit(damage);

        }
        Instantiate(Effect, transform.position, transform.rotation);
        Destroy(gameObject); // Deletes the round
    }
   
}
