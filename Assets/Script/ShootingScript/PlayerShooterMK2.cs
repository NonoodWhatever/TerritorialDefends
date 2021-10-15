using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Credit to thfm
public class PlayerShooterMK2 : MonoBehaviour
{
    public Gun gun;

    public int shootButton;
    public KeyCode reloadKey;

    void Update()
    {
        if (Input.GetMouseButton(shootButton))
        {
            gun.Shoot();
        }

        if (Input.GetKeyDown(reloadKey))
        {
            gun.Reload();
        }
    }
}
