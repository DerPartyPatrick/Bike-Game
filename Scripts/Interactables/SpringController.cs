using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour
{
    public bool isOnSide; 

    private SpringJoint2D spring;
    private Rigidbody2D rb;
    private Vector3 startPosition;  

    private void Start()
    {
        startPosition = transform.position; 
        spring = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>(); 
    }

    public void Activate()
    {
        spring.enabled = true;
        if (!isOnSide)
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        else
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
    }

    private void FixedUpdate()
    {
        if(transform.position.y < startPosition.y)
        {
            transform.position = startPosition; 
        }
    }
}
