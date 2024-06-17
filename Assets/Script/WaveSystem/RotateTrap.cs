using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateTrap : MonoBehaviour
{
    public Collider onHitCollider;
    public TestTargetRotation targetRotation;
    public float speed;
    public float treshold;
    public float trapTime;
    public int randomNumber;

    public GameObject particle;
    public ParticleSystem fire;
    public bool onFire = false;
    public bool activateTrap;

    public float time;
    public float timeTreshHold;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= timeTreshHold) 
        {
            randomNumber = GetRandomNumber();
            Debug.Log(randomNumber);
            time -= time;
        }
       

        if(randomNumber <= 1)
        {
            trapTime = Random.Range(0, treshold);
            StartCoroutine(TimerTrap(trapTime));
        }

        
        if(activateTrap)
        {
            onHitCollider.enabled = true;
            particle.SetActive(true);
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            onHitCollider.enabled = false;
            StopCoroutine(TimerTrap(trapTime));
            particle.SetActive(false);
        }
    }
    public IEnumerator TimerTrap(float t)
    {
        activateTrap = true;
        yield return new WaitForSeconds(t);
        activateTrap = false;
    }
    public int GetRandomNumber()
    {
        int value = Random.Range(0, 4);
        
        return value;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("Hit");
            fire = other.gameObject.GetComponentInParent<TestTargetRotation>().GetComponentInChildren<ParticleSystem>();
            if (fire != null)
            {
                fire.Play();
                onFire = true;
            }
        }
      
        
    }
    
}
