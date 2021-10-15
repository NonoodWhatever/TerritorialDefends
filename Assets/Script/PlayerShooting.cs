using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    //Credit to XxSaiFxX and softwizz for this code
    public Rigidbody bullet;
    public float bulletspeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        //no
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody instantiatedProjectile = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, bulletspeed));
        }
    }
}
