using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerinArena : MonoBehaviour
{
    public Spawner spawner;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Body"))
        {
            spawner.playerInArena = true;
        }
    }
}
