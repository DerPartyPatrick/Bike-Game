using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class UIController : MonoBehaviour
{
    public LevelController levelController;
    public GameObject nextButton;
    public PresentUIController presents;
    public GameObject winCanvas; 

    private void Start()
    {
        Level level = Progress.GetLevel(levelController.levelId);
        if (level != null && level.collectedPresents > 0) ActivateNext(); 
    }

    public void Win()
    {
        if(winCanvas != null)
            winCanvas.SetActive(true); 
    }

    public void PresentCollected()
    {
        presents.CollectPresent(); 
    }

    public void ActivateNext()
    {
        if(nextButton != null)
            nextButton.SetActive(true); 
    }

    public void onHomeClick()
    {
        SceneManager.LoadScene("Home"); 
    }

    public void onRetryClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void onNextClick()
    {
        SceneManager.LoadScene("Level" + (levelController.levelId+1).ToString()); 
    }
}
