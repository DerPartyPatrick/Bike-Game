using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PresentUIController : MonoBehaviour
{
    public Image[] presents; 
    public Sprite present;

    private int next = 0; 

    public void CollectPresent()
    {
        if (next >= presents.Length) return;
        presents[next].sprite = present;
        presents[next].color = Color.white; 
        next++; 
    }
}
