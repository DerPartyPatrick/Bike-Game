using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    public GameObject link;
    public HingeJoint2D hook;
    public int length;
    public Rigidbody2D cargo; 

    private void Start()
    {
        HingeJoint2D last = hook;

        for (int i = 0; i < length; i++)
        {
            Vector2 position = last.transform.position + new Vector3(0, -0.1f, 0);
            GameObject l = Instantiate(link, position, new Quaternion());
            l.transform.parent = transform;
            Rigidbody2D rb = l.GetComponent<Rigidbody2D>();
            last.connectedBody = rb;
            last = l.GetComponent<HingeJoint2D>();
        }

        if(cargo == null)
        {
            last.enabled = false;
            return;
        }

        last.connectedAnchor = Vector2.zero;
        last.connectedBody = cargo;
    }
}
