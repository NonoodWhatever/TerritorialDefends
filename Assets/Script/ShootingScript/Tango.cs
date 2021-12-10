using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Credit to thfm
public class Tango : MonoBehaviour
{
    public float health;
    [SerializeField]
    GameObject deathEffect;
    [SerializeField]
    int Points;
    public GameObject spawn;
    public bool isLivingBullet = false;


    void Start()
    {
       
    }
    void Update()
    {
        if (health <= 0)
        {   
            die();
        }
    }

    /// 'Hits' the target for a certain amount of damage
    public void Hit(float damage)
    {
        health -= damage;
    }
    public void die()
    {
        GameInfoForUI.instance.PlayerScoreUpdate(Points);
       Instantiate(deathEffect, transform.position, Quaternion.identity);
      Destroy(gameObject);
    }
}
