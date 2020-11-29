using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress
{
    public static void SaveLevel(Level level)
    {
        string key = "Level" + level.id.ToString() + "_Presents";
        PlayerPrefs.SetInt(key, level.collectedPresents); 
    }

    //returns null if Level does not exist yet
    public static Level GetLevel(int id)
    {
        string key = "Level" + id.ToString() + "_Presents";
        if (!PlayerPrefs.HasKey(key)) return null;
        int presents = PlayerPrefs.GetInt(key);
        return new Level(id, presents); 
    }
}