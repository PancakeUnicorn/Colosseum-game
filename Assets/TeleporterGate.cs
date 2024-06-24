using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterGate : MonoBehaviour
{
    public ButtonConfirm buttonConfirm;
    public Transform player;
    // Start is called before the first frame update
    public void Update()
    {
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerinArena"))
        {
            player.transform.position = buttonConfirm.spawnInArena.transform.position;
        }
       
    }
}
