using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int levelId;
    public UIController ui;
    public InputManager input; 

    private int presentsCounter = 0;
    private int savedPresents = 0; 

    private void Start()
    {
        Level level = Progress.GetLevel(levelId);
        if (level != null) savedPresents = level.collectedPresents; 
    }

    public void CollectPresent()
    {
        ui.ActivateNext();
        ui.PresentCollected(); 
        presentsCounter++;

        if (presentsCounter == 3 && levelId != 20)
        {
            ui.Win();
            input.BlockInput(); 
        } 
    }

    private void OnDestroy()
    {
        if (presentsCounter > savedPresents)
            Progress.SaveLevel(new Level(levelId, presentsCounter)); 
    }
}
