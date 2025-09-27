using System;
using System.Collections;
using UnityEngine;

public class BatSwing : MonoBehaviour
{
    public float swingAngle = 60f;
    public float swingSpeed = 5f;
    public float hitForce = 10f; // force applied to the ball
    private Quaternion startRotation;
    private Quaternion swingRotation;
    private bool swinging = false;
    private bool pause = false;
    void Start()
    {
        startRotation = transform.localRotation;
        swingRotation = Quaternion.Euler(0, swingAngle, 0) * startRotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !swinging)
        {
            StartCoroutine(Swing());
        }
        
    }

    private IEnumerator Swing()
    {
        swinging = true;

        // Forward swing
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime * swingSpeed;
            transform.localRotation = Quaternion.Slerp(startRotation, swingRotation, t);
            Physics.SyncTransforms();
            yield return null;
        }

        // Return swing
        t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime * swingSpeed;
            transform.localRotation = Quaternion.Slerp(swingRotation, startRotation, t);
            Physics.SyncTransforms();
            yield return null;
        }


        swinging = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Apply force in the bat's forward direction
                rb.AddForce(transform.forward * hitForce, ForceMode.Impulse);
            }
        }
    }
}
