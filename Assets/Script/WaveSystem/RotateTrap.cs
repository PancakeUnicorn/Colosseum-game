using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateTrap : MonoBehaviour
{
    public TestTargetRotation targetRotation;
    public float speed;
    public float treshold;
    public GameObject animation;
    public ParticleSystem fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(targetRotation.distance <= treshold)
        {
           animation.SetActive(true);
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            animation.SetActive(false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        fire = other.gameObject.GetComponentInParent<TestTargetRotation>().GetComponentInChildren<ParticleSystem>();
        fire.Play();
        
    }
}
