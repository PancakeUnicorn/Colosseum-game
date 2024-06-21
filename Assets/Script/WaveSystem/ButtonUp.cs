using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation.Samples;
using UnityEngine;

public class ButtonUp : MonoBehaviour
{
    public Spawner spawner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Left"|| other.tag =="Right" || other.tag == "Boxing")
        {
            if (spawner.amount <= 6)
            {
                spawner.amount += 1;
            }
            else
            {
                spawner.amount = 6;
            }

        }


    }
}
