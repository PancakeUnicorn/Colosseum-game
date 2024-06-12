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
        if(collision.collider.tag == "ButtonUp")
        {
            spawner.amount += 1;
        }
        if(collision.collider.tag == "ButtonDown")
        {
            spawner.amount -= 1;
        }
        if(collision.collider.tag == "Continue")
        {
            botAmount.SetActive(false);
            panelPickWeapon.SetActive(true);
            readyToSpawn = true;
        }
        if(collision.collider.tag == "Continue" && readyToSpawn)
        {
            player.transform.position = spawnPosition.position;
        }
        i
    }
}
