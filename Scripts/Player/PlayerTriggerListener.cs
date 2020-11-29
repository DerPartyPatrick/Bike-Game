using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerListener : MonoBehaviour
{
    public Rigidbody2D bike;
    public Rigidbody2D wheel1;
    public Rigidbody2D wheel2;

    private Collider2D currentTrigger;
    private LevelController level;

    private void Start()
    {
        GameObject l = GameObject.FindGameObjectWithTag("LevelController");
        level = l.GetComponent<LevelController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentTrigger = collision; 
        if (collision.CompareTag("Booster")) BoosterTrigger();
        else if (collision.CompareTag("Present")) PresentTrigger();
    }

    private void BoosterTrigger()
    {
        BoosterController booster = currentTrigger.GetComponent<BoosterController>(); 
        float boost = booster.boost;
        float deceleration = booster.deceleration; 
        Vector2 boosterDir = booster.transform.right;
        if (!booster.directionRight) boosterDir *= -1;
        float angle = Vector2.SignedAngle(boosterDir, bike.velocity);
        if (angle > 90 || angle < -90)
        {
            bike.velocity *= deceleration;
            wheel1.velocity = bike.velocity;
            wheel2.velocity = bike.velocity;
            wheel1.angularVelocity *= deceleration;
            wheel2.angularVelocity *= deceleration;
            return; 
        }

        bike.velocity *= boost;
        wheel1.velocity = bike.velocity;
        wheel2.velocity = bike.velocity;
        wheel1.angularVelocity *= boost;
        wheel2.angularVelocity *= boost;
    }

    private void PresentTrigger()
    {
        Destroy(currentTrigger.transform.parent.gameObject);
        level.CollectPresent(); 
    }
}
