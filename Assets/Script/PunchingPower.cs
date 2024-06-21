using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PunchingPower : MonoBehaviour
{
    public float power;
    public float damage;
    public float timer;
    XRIDefaultInputActions input;
    public Health health;
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
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Health health = collision.gameObject.GetComponentInParent<Health>();
            if (health != null)
            {
                Debug.Log("pow");
                health.lifePoints -= damage;
                gameObject.GetComponent<SphereCollider>().enabled = false;
                timer -= Time.time;
            }
            if (rb != null)
            {
                if(health.lifePoints > 30)
                {
                    rb.AddForce(forceDirection * power, ForceMode.Impulse);
                }
             

            }
            if(timer <= 0)
            {
                gameObject.GetComponent<SphereCollider>().enabled = true;
                timer = 1;
            }
        }

    }
}
