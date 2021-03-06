using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
// Credit to thfm
public class Gun : MonoBehaviour
{
  
    public enum ShootState
    {
        Ready,
        Shooting,
        Reloading
    }

    // How far forward the muzzle is from the centre of the gun
    private float muzzleOffset;

    [Header("Magazine")]
    public GameObject round;
    public int ammunition;
    public AudioSource NOISE;


    [Range(0.5f, 20)] public float reloadTime;

    private int remainingAmmunition;

    [Header("Shooting")]
    // How many shots the gun can make per second
    [Range(0.25f, 100)] public float fireRate;

    // The number of rounds fired each shot
    public int roundsPerShot;

    [Range(0.5f, 100)] public float roundSpeed;

    // The maximum angle that the bullet's direction can vary,
    // in both the horizontal and vertical axes
    [Range(0, 60)] public float maxRoundVariation;

    private ShootState shootState = ShootState.Ready;

    // The next time that the gun is able to shoot at
    private float nextShootTime = 0;

    void Start()
    {
        muzzleOffset = GetComponent<Renderer>().bounds.extents.z;
        remainingAmmunition = ammunition;
        GameInfoForUI.instance.PlayerMaxAmmo(ammunition);
    }

    void Update()
    {
        switch (shootState)
        {
            case ShootState.Shooting:
                // If the gun is ready to shoot again...
                if (Time.time > nextShootTime)
                {
                    shootState = ShootState.Ready;
                }
                break;
            case ShootState.Reloading:
                // If the gun has finished reloading...
                if (Time.time > nextShootTime)
                {
                    remainingAmmunition = ammunition;
                    shootState = ShootState.Ready;
                    GameInfoForUI.instance.PlayerAmmoUpdate(remainingAmmunition);
                }
                break;
        }
    }

    /// Attempts to fire the gun
    public void Shoot()
    {
        // Checks that the gun is ready to shoot
        if (shootState == ShootState.Ready)
        {
            NOISE.Play();
            for (int i = 0; i < roundsPerShot; i++)
            {
                // Instantiates the round at the muzzle position
                GameObject spawnedRound = Instantiate(
                    round,
                    transform.position + transform.forward * muzzleOffset,
                    transform.rotation
                );

                // Add a random variation to the round's direction
                spawnedRound.transform.Rotate(new Vector3(
                    Random.Range(-1f, 1f) * maxRoundVariation,
                    Random.Range(-1f, 1f) * maxRoundVariation,
                    0
                ));

                Rigidbody rb = spawnedRound.GetComponent<Rigidbody>();
                rb.velocity = spawnedRound.transform.forward * roundSpeed;
                
            }

            remainingAmmunition--;
            if (remainingAmmunition > 0)
            {
                nextShootTime = Time.time + (1 / fireRate);
                shootState = ShootState.Shooting;
                GameInfoForUI.instance.PlayerAmmoUpdate(remainingAmmunition);
            }
            else
            {
                Reload();
            }
        }
    }

    /// Attempts to reload the gun
    public void Reload()
    {
        // Checks that the gun is ready to be reloaded
        if (shootState == ShootState.Ready)
        {
            nextShootTime = Time.time + reloadTime;
            shootState = ShootState.Reloading;
        }
    }
}