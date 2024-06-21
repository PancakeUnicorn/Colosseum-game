using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonConfirm : MonoBehaviour
{
    public GameObject player;
    public GameObject teleporter;
    public GameObject botAmount;
    public GameObject panelPickWeapon;
    public Transform spawnInArena;
    public bool readyToSpawn = false, hasSpawned, teleporterActive;
    public void Update()
    {
        if (readyToSpawn)
        {
            teleporterActive = true;
            hasSpawned = true;
        }

        if (teleporterActive) 
        {
            teleporter.SetActive(true);
        }
        else
        {
            teleporter.SetActive(false);
        }
        if (hasSpawned) 
        {
            readyToSpawn = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Left") || other.CompareTag("Right") || other.CompareTag("Boxing"))
        {
           
            botAmount.SetActive(false);
            panelPickWeapon.SetActive(true);
            readyToSpawn = true;
            Debug.Log(readyToSpawn);

        }
    }

}
