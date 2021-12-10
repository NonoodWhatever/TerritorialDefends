using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    

    public static void Init()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void Save(string SaveString)
    {
        File.WriteAllText(SAVE_FOLDER + "/SavedScore.txt", SaveString);
    }
    public static string Load()
    {
        if(File.Exists(SAVE_FOLDER + "/SavedScore.txt"))
        {
            string SaveString = File.ReadAllText(SAVE_FOLDER + "/SavedScore.txt");
            return SaveString;
        }
        else
        {
            return null;
        }
    }




}
