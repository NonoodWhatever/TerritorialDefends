using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighscoreSystemForLeaderboard : MonoBehaviour
{
    SaveData TheData;
  
   private class SaveData
    {
        public int TheEndScore;
    }
    void OnEnable()
    {
    }
    void Update()
    {

    }

    void SaveInfo()
    {
        int score = GameInfoForUI.instance.Score;
        SaveData NewSaveData = new SaveData();
        NewSaveData.TheEndScore = score;


        string jsonSaveString = JsonUtility.ToJson(NewSaveData);

        string saveLocation = Application.dataPath;
        // I know this will be gone, but whatever
        File.WriteAllText(saveLocation + "/SaveScoreForTD/SavedScore.txt", jsonSaveString);
    }

    void LoadInfo()
    {
        string saveLocation = Application.dataPath;
        if(File.Exists(saveLocation + "/SaveScoreForTD/SavedScore.txt")== true)
        {
            string loadtheString = File.ReadAllText(saveLocation + "/SaveScoreForTD/SavedScore.txt");
            TheData = JsonUtility.FromJson<SaveData>(loadtheString);
        }
    }
}
