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
        if(other.tag == "Left" || other.tag == "Right")
        {
            spawner.amount -= 1;
        }
            
        
    }
}
