using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PunchingPower : MonoBehaviour
{
    public float power;
    XRIDefaultInputActions input;
    public InputActionProperty velocity;

    void Start()
    {
        
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contactPoint = collision.GetContact(0);


        Vector3 forceDirection = collision.transform.position - contactPoint.point;
        forceDirection= forceDirection.normalized;
        Rigidbody rb = collision.rigidbody;
        if (rb != null)
        {
        
            rb.AddForce(forceDirection * power, ForceMode.Impulse);
            
        }

    }
}
