using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPositions;
    public GameObject[] prefabToSpawn;
    public int[] amount;
    public bool position1,position2,position3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SpawnEnemys();
            Debug.Log("Pain");
        }
    }
    public void SpawnEnemys() 
    {

        var enemy = Random.Range(0, prefabToSpawn.Length);
        var spawn = Random.Range(0, spawnPositions.Length);

        Instantiate(prefabToSpawn[enemy], spawnPositions[spawn].position, Quaternion.identity);
    }

}
