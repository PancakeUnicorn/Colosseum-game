using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshPro count;
    public GameObject botAmount;
    public GameObject panelPickWeapon;
    public Spawner spawner;
    public bool readyToSpawn;
    public Transform player;
    public Transform spawnPosition;
    public bool testUp;
    public bool testDown;
    public bool testNext;
    public bool testPrevious;
    public bool testSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {   
        if(collision.collider.tag == "ButtonUp" || testUp)
        {
            spawner.amount += 1;
        }
        if(collision.collider.tag == "ButtonDown"|| testDown)
        {
            spawner.amount -= 1;
        }
        if(collision.collider.tag == "Continue" || testNext)
        {
            botAmount.SetActive(false);
            panelPickWeapon.SetActive(true);
            readyToSpawn = true;
        }
        if(collision.collider.tag == "Continue" && readyToSpawn|| testSpawn)
        {
            player.transform.position = spawnPosition.position;
        }
        if(collision.collider.tag == "Previous"|| testPrevious)
        {
            panelPickWeapon.SetActive(false);
            botAmount.SetActive(true);
        }
    }
}
