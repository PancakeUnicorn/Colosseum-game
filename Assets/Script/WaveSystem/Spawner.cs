using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPositions;
    public GameObject[] prefabToSpawn;
    public Transform loadOutZone;
    public int amount;
    public bool position1,position2,position3;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    public bool hasSpawned = false;
    public bool playerInArena = false;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasSpawned && playerInArena )
        {
            SpawnEnemys();
            hasSpawned = true;

        }
        if (hasSpawned)
        {
            CheckEnemies();
        }
       
    }
    public void SpawnEnemys() 
    {
        for (int i = 0; i < amount; i++)
        {
            var enemy = Random.Range(0, prefabToSpawn.Length);
            var spawn = Random.Range(0, spawnPositions.Length);

            GameObject enemie = Instantiate(prefabToSpawn[enemy], spawnPositions[spawn].position, Quaternion.identity);
            spawnedEnemies.Add(enemie);
        }
      
    }
    public void CheckEnemies()
    {
        spawnedEnemies.RemoveAll(item => item == null);
        if (spawnedEnemies.Count == 0 && amount > 0)
        {
            TeleportBack();
            hasSpawned = false ;
        }
    }
    public void TeleportBack()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            player.transform.position = loadOutZone.position;
        }
    }
}
