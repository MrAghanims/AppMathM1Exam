using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSwing : MonoBehaviour
{
    public Transform bat;        
    public float swingSpeed = 500f; 
    public float swingAngle = 90f;  
    private bool swinging = false;
    private Quaternion initialRotation;

    void Start()
    {
        if (bat != null)
            initialRotation = bat.localRotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !swinging)
        {
            StartCoroutine(Swing());
        }
    }

    private System.Collections.IEnumerator Swing()
    {
        swinging = true;

        // Swing forward
        float elapsed = 0f;
        while (elapsed < 0.2f)
        {
            bat.localRotation = initialRotation * Quaternion.Euler(0, -swingAngle * (elapsed / 0.2f), 0);
            elapsed += Time.deltaTime * swingSpeed / 100f;
            yield return null;
        }

        // Swing back
        elapsed = 0f;
        while (elapsed < 0.2f)
        {
            bat.localRotation = initialRotation * Quaternion.Euler(0, -swingAngle * (1 - (elapsed / 0.2f)), 0);
            elapsed += Time.deltaTime * swingSpeed / 100f;
            yield return null;
        }

        bat.localRotation = initialRotation;
        swinging = false;
    }
}