using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class LevelButtonController : MonoBehaviour
{
    public Sprite lockedIdle;
    public Sprite lockedPressed;
    public Sprite finishedIdle;
    public Sprite finishedPressed;
    public Image image;
    public Button button;
    public Text number;

    private int id;
    private bool locked = false; 
    
    public void SetLocked()
    {
        image.sprite = lockedIdle;
        SpriteState state = button.spriteState;
        state.pressedSprite = lockedPressed;
        button.spriteState = state;
        number.text = "";
        locked = true; 
    }

    public void SetFinished()
    {
        image.sprite = finishedIdle;
        SpriteState state = button.spriteState;
        state.pressedSprite = finishedPressed;
        button.spriteState = state; 
    }

    public void SetId(int id)
    {
        this.id = id;
        number.text = id.ToString(); 
    }

    public void OnClick()
    {
        if(!locked)
        {
            SceneManager.LoadScene("Level" + id.ToString());
        }
    }
}
