using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levels;
    public GameObject credits;

    public void onStartClick()
    {
        mainMenu.SetActive(false);
        credits.SetActive(false); 
        levels.SetActive(true); 
    }

    public void onHomeClick()
    {
        levels.SetActive(false);
        credits.SetActive(false); 
        mainMenu.SetActive(true); 
    }

    public void onCreditsClick()
    {
        levels.SetActive(false);
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit(); 
    }
}
