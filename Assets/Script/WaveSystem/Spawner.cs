using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public Transform[] spawnPositions;
    public GameObject[] prefabToSpawn;
    public Transform loadOutZone;
    public int amount;
    public bool position1,position2,position3;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    public bool hasSpawned = false;
    public bool playerInArena = false;  
    public bool roundHasEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!roundHasEnded)
        {
            if (!hasSpawned && playerInArena)
            {
                SpawnEnemys();
                hasSpawned = true;

            }
            if (hasSpawned)
            {
                CheckEnemies();
            }
        }
        else
        {
            TeleportBack();
        }
       
    }
    public void SpawnEnemys() 
    {
        if (!roundHasEnded)
        {
            for (int i = 0; i < amount; i++)
            {
                var enemy = Random.Range(0, prefabToSpawn.Length);
                var spawn = Random.Range(0, spawnPositions.Length);

                GameObject enemie = Instantiate(prefabToSpawn[enemy], spawnPositions[spawn].position, Quaternion.identity);
                spawnedEnemies.Add(enemie);
            }
        }
        else
        {
            TeleportBack();
        }
      
    }
    public void CheckEnemies()
    {
        spawnedEnemies.RemoveAll(item => item == null);
        if (spawnedEnemies.Count == 0)
        {
          
            roundHasEnded = true;
        }
    }
    public void TeleportBack()
    {
        
        if(player != null)
        {
            player.transform.position = loadOutZone.position;
            hasSpawned = false;
        }
    }
}
