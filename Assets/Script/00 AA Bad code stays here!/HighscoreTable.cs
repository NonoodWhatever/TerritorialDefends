using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

/// <summary>
/// This is found in code monkey.
/// </summary>
public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    // Start is called before the first frame update
    private void Awake()
    {
        entryContainer = transform.Find("ScoreContainer");
        entryTemplate = entryContainer.Find("ScoreTemplate");
        entryTemplate.gameObject.SetActive(false);

       /*  highscoreEntryList = new List<HighscoreEntry>()
         {
             new HighscoreEntry {score = 144445, name= "Josh" },
             new HighscoreEntry {score = 1235, name= "Thomas" },
             new HighscoreEntry {score = 2355, name= "eee" },
             new HighscoreEntry {score = 3452345, name= "Fun" },
             new HighscoreEntry {score = 253245, name= "420" },
             new HighscoreEntry {score = 25, name= "eeer" },
             new HighscoreEntry {score = 5235, name= "42460" },
             new HighscoreEntry {score = 24623, name= "eqer" },
             new HighscoreEntry {score = 1235, name= "Jane" },
         };*/

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscore = JsonUtility.FromJson<Highscores>(jsonString);
        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if(highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    //swap tem
                    HighscoreEntry better = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = better;
                }
            }
        }


        highscoreEntryTransformList = new List<Transform>();
        
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransofrm(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        /*
        Highscores highscore = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscore);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));*/

    }
   
    private void CreateHighscoreEntryTransofrm(HighscoreEntry highscore, Transform container, List<Transform> transformList )
    {
        float templateHeight = 40f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryrectTransform = entryTransform.GetComponent<RectTransform>();
        entryrectTransform.anchoredPosition = new Vector2(0, (-templateHeight * transformList.Count)+40);
        entryTransform.gameObject.SetActive(true);
        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {default:
            rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }
        entryTransform.Find("PosText").GetComponent<Text>().text = rankString;
        int score = highscore.score;
        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();
        string name = highscore.name;
        entryTransform.Find("NameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    [System.Serializable] class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }
    [System.Serializable]private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}

