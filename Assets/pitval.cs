using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitval : MonoBehaviour
{
    public Transform teleportBack;
    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Health>().Death();
        }
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportBack.position;
        }
    }
}
