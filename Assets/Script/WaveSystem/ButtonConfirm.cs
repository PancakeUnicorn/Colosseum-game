using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonConfirm : MonoBehaviour
{
    public GameObject player;
    public GameObject botAmount;
    public GameObject panelPickWeapon;
    public Transform spawnInArena;
    public bool readyToSpawn = false, hasSpawned;
    public void Update()
    {
        if (readyToSpawn)
        {
            player.transform.position = spawnInArena.position;
            hasSpawned = true;
        }
        if (hasSpawned) 
        {
            readyToSpawn = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Left") || other.CompareTag("Right"))
        {
           
            botAmount.SetActive(false);
            panelPickWeapon.SetActive(true);
            readyToSpawn = true;
            Debug.Log(readyToSpawn);

        }
    }
}
