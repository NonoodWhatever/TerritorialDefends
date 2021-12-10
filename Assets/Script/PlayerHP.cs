using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public int MaxHP = 100;
    public int currentHealth;
    public HitPoint HitPoint;
    int Timer = 0;
    public int SelectedTimer = 30;
    public GameObject weapon;

    // Start is called before the first frame update
    public void Start()
    {
        currentHealth = MaxHP;
        GameInfoForUI.instance.PlayerHPUpdate(currentHealth);
         Timer = 0;
    }

    // Update is called once per frame
    // void OnTriggerEnter(Trigger collision)
    // {
    //     
    //  }
    public void Update()
    {
        if (Timer != 0)
        {
            Timer -= 1;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        Tango ouch = other.gameObject.GetComponent<Tango>();
        if (Timer == 0 && currentHealth > 0)
        {
            if (ouch != null) 
            {
                currentHealth -= 1; 
                print("ouch"); 
                Timer = SelectedTimer; 
                GameInfoForUI.instance.PlayerHPUpdate(currentHealth);
                if (ouch.isLivingBullet == true)
                {
                    ouch.die();
                }
            }
            
            
        }
        else if (currentHealth == 0)
        {
            print("u ded");
            GameInfoForUI.instance.SaveInfo();
            Destroy(weapon);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("GameOver");
        }
        else if (Timer != 0)
        {
            print("time out");
        }
        else
        {
            print("code broke");
        }
    }
}
