using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerArenaTrigger : MonoBehaviour
{
    public AudioSource soundSource;
    public bool test;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerinArena"))
        {
            test = true;
            soundSource.enabled = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerinArena"))
        {
            test = false;
            soundSource.enabled = false;
        }
    }
}
