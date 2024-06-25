using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitval : MonoBehaviour
{
    public Transform teleportBack;
    public Health enemyHealthScript;
    public Transform player;
    // Start is called before the first frame update

    public void OnTriggerStay (Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyHealthScript = other.GetComponentInParent<Health>();
            enemyHealthScript.Death();
            Debug.Log("kill");
        }
        if (other.CompareTag("PlayerInArena"))
        {
            player.transform.position = teleportBack.position;
        }
    }
}
