using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalkToPlayer : MonoBehaviour
{
 
    public GameObject target;
    NavMeshAgent nav;
  //  public int Cooldown = 5;
    bool knockback;
    Vector3 directionKB;
    public int WalkSpeed;
    public void Start()
    {
        knockback = false;
        nav = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {// Hope this works
       target = GameObject.Find("Player");
        if (knockback)
        {
            nav.velocity = directionKB * 8;
        }
     //Comment: HOW THE FUCK DO I MAKE ENEMY GO TO PREFAB WITHOUT GOING TO POSITION! FUCK!!!!!!!!!
         nav.SetDestination(target.transform.position);
        //nav.SetDestination(target.position);
    }
    IEnumerator KB() 
    {
        knockback = true;
        nav.speed = 10;
        nav.angularSpeed = 0;
        nav.acceleration = 500;

        yield return new WaitForSeconds(0.5f);

        knockback = false;
        nav.speed = WalkSpeed;
        nav.angularSpeed = 270;
        nav.acceleration = 25;
    }


}
