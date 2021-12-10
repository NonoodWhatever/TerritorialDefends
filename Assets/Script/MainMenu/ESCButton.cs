using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class ESCButton : MonoBehaviour
{
    private float Timer;
    public TMP_Text USure;
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Timer = 5;
            //Application.Quit();
            if (Timer >= 0)
            {
                USure.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    GameInfoForUI.instance.SaveInfo();
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    SceneManager.LoadScene("GameOver");
                }
            }
     
            

        }
        if(Timer <= 0)
        {
            USure.gameObject.SetActive(false);
        }

    }
}
