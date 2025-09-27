using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitBorder : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(0, 2, -5); // Set where ball should respawn
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Border"))
        {
            FindObjectOfType<PlayerLives>().TakeHit();

            transform.position = respawnPosition;

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }



}