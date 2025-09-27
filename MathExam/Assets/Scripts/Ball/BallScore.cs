using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScore : MonoBehaviour
{
    private Rigidbody rb;
    public float speedIncrease = 1f; 
    public float maxSpeed = 50f;       

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if ball hit the scoring wall
        if (collision.gameObject.CompareTag("ScoreWall"))
        {
            IncreaseSpeed();
            ScoreManager.Instance.AddScore(1);
        }
    }

    void IncreaseSpeed()
    {
        rb.velocity = rb.velocity.normalized * Mathf.Min(rb.velocity.magnitude + speedIncrease, maxSpeed);
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}