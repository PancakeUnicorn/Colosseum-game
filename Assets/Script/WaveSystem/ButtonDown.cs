using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.AI.Navigation.Samples;
using UnityEngine;

public class ButtonDown : MonoBehaviour
{
    
    
  
    public Spawner spawner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Left") || other.CompareTag("Right"))
        {
            if (spawner.amount <= 6) 
            {
                spawner.amount -= 1;
            }
            else
            {
                spawner.amount = 6;
            }
            
        }
            
        
    }
}
