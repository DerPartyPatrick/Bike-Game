using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeController : MonoBehaviour
{
    private void Update()
    {
        Vector2 lastPosition = transform.position; 
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = newPosition - lastPosition;

        //collision detection 
        RaycastHit2D hit = Physics2D.Raycast(lastPosition, direction); 

        if(hit.collider != null && hit.distance <= direction.magnitude && hit.collider.CompareTag("RopeLink")) 
        {
            Destroy(hit.collider.gameObject); 
        }

        transform.position = newPosition; 
    }
}
