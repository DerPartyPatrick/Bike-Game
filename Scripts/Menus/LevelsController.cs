using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsController : MonoBehaviour
{
    public GameObject levelsParent;

    private LevelButtonController[] levelButtons; 

    private void Start()
    {
        levelButtons = levelsParent.GetComponentsInChildren<LevelButtonController>();
        Level lastLevel = null; 

        for(int i=0; i<levelButtons.Length; i++)
        {
            levelButtons[i].SetId(i + 1); 
            Level currentLevel = Progress.GetLevel(i + 1);
            if (i!=0 && (lastLevel == null || lastLevel.collectedPresents == 0)) levelButtons[i].SetLocked();
            else if (currentLevel != null && currentLevel.collectedPresents >= 3) levelButtons[i].SetFinished(); 
            lastLevel = currentLevel; 
        }
    }
}
