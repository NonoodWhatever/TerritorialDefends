using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
public class GameInfoForUI : MonoBehaviour
{
    

    public static GameInfoForUI instance;
  
    private void Awake()
    {
    instance = this;
    }
    
    [SerializeField]
    TMP_Text ui_ScoreText;
    [SerializeField]
    TMP_Text ui_HPText;
    [SerializeField]
    Slider ui_AmmoValue;
    [SerializeField]
    TMP_Text ui_ReloadingText;
    public int Score = 0;
    int HP = 9;
    float ouchTime;
    [SerializeField]
    Image OuchOverall;
    Text words;

    [SerializeField]
    TMP_Text HighScore;


    
    //public Vector3 ScaleChange { get; private set; }
    
    // Update is called once per frame
   
    private void Start()
    {
        if (HighScore.gameObject != null)
        {
            LoadInfo();
        }
       
    }






    private void Update()
    {
        ouchTime -= Time.deltaTime;
        if (ui_ReloadingText != null)
        {
            if (ui_AmmoValue.value >= ui_AmmoValue.maxValue - 1)
            {
                ui_ReloadingText.gameObject.SetActive(false);
            }
            if (ouchTime <= 0)
            {
                OuchOverall.gameObject.SetActive(false);
            }
            else
            {
                OuchOverall.gameObject.SetActive(true);
            }
        }
        
    }
    public void PlayerScoreUpdate(int amountToUpdate)
    {
        Score += amountToUpdate;
        ui_ScoreText.text = "Score: " + Score;
    }
    public void PlayerHPUpdate(int amountToUpdate)
    {
        HP = amountToUpdate;
        ui_HPText.text = "HP: " + HP;
        ouchTime = 0.1f;
    }
    public void PlayerMaxAmmo(int ammo)
    {
        ui_AmmoValue.maxValue = ammo;
        ui_AmmoValue.value = ammo;
    }
    public void PlayerAmmoUpdate(int ammo)
    {
        ui_AmmoValue.value = ammo;
    }
    public void PlayerReloading()
    {
        ui_ReloadingText.gameObject.SetActive(true);
    }

    public void PlayerNameSet(Text Name)
    {
        //none
    }




    SaveData TheData;

    private class SaveData
    {
        public int TheEndScore;
    }
    public void SaveInfo()
    {
        SaveSystem.Init();

        int score = GameInfoForUI.instance.Score;
        SaveData NewSaveData = new SaveData();
        NewSaveData.TheEndScore = score;


        string jsonSaveString = JsonUtility.ToJson(NewSaveData);
        // I know this will be gone, but whatever
        SaveSystem.Save(jsonSaveString);
        
    }

    // More I think how to make things save, more I wanna vomit.
    public void LoadInfo()
    {
        string SaveString = SaveSystem.Load();
        if (SaveString != null)
        {
          TheData = JsonUtility.FromJson<SaveData>(SaveString);
     HighScore.text = "Previous Score:" + TheData.TheEndScore;
        }
        else 
        {
     HighScore.text = "Bug happens or this is your first time, Play a round to fix!"; 
        }



    }






    }
