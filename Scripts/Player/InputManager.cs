using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class InputManager : MonoBehaviour
{
    public GameObject bike;
    public GameObject blade; 
    public float minCutVelocity; //set to 1000

    private Vector2 startPosition; 
    private Vector2 lastPosition;
    private Vector2 worldPosition;
    private Vector2 lastWorldPosition; 

    private bool bikeSpawned = false;
    private GameObject currentBlade;
    private bool inputBlocked = false; 

    private void Update()
    {
        if (!inputBlocked)
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0)) MouseDown();
            else if (Input.GetMouseButton(0)) MouseMoved();
            else if (Input.GetMouseButtonUp(0)) MouseUp(); 
        }
    }

    public void BlockInput()
    {
        inputBlocked = true; 
    }

    private void MouseDown()
    {
        startPosition = Input.mousePosition; 
        lastPosition = startPosition; 
    }

    private void MouseMoved()
    {
        Vector2 direction = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - lastPosition;
        float velocity = direction.magnitude / Time.deltaTime; 

        if (velocity >= minCutVelocity && currentBlade == null)
        {
            currentBlade = Instantiate(blade, worldPosition, new Quaternion());
            currentBlade.transform.parent = transform;
        }

        lastPosition = Input.mousePosition; 
    }

    private void MouseUp()
    {
        Destroy(currentBlade); 
        float epsilon = 0.1f;
        if (Vector2.Distance(startPosition, Input.mousePosition) > epsilon) return; 

        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero); 

        if(hit.collider == null)
        {
            Collider2D[] c = Physics2D.OverlapCircleAll(worldPosition, 0.5f);
            bool spawn = true; 


            if(c != null)
            {
                for(int i=0; i<c.Length; i++)
                {
                    if(!c[i].CompareTag("BoosterTouch") && !c[i].CompareTag("SpringTouch"))
                    {
                        spawn = false;
                    }
                }
            }

            if(spawn) SpawnBike(); 
        }
        else
        {
            GameObject hitObj = hit.collider.gameObject;
            if (hitObj.CompareTag("BoosterTouch")) BoosterTouch(hitObj);
            else if (hitObj.CompareTag("SpringTouch")) SpringTouch(hitObj);
        }
    }

    private void BoosterTouch(GameObject hit)
    {
        BoosterController booster = hit.transform.parent.GetComponent<BoosterController>();
        booster.changeDirection();
    }

    private void SpringTouch(GameObject hit)
    {
        SpringController spring = hit.transform.parent.GetComponent<SpringController>();
        spring.Activate();
    }

    private void SpawnBike()
    {
        if(!bikeSpawned)
        {
            bikeSpawned = true;
            Instantiate(bike, worldPosition, new Quaternion());
        }
    }
}