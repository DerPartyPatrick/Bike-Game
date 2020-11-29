using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterController : MonoBehaviour
{
    public bool directionRight = true;
    public float boost;
    public float deceleration; 
    public GameObject arrows; 

    public void changeDirection()
    {
        directionRight = !directionRight;
        arrows.transform.localScale = new Vector3(-arrows.transform.localScale.x, arrows.transform.localScale.y, arrows.transform.localScale.z); 
    }
}
