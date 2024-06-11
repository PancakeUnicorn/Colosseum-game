using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
          Debug.Log("FoumdEnemy");
            if (other.attachedRigidbody)
            {
                Debug.Log("Setting kinematic");
                other.attachedRigidbody.isKinematic = true;
            }

            other.GetComponent<Health>().Death();
            other.attachedRigidbody.isKinematic = true;
      
    }
    public void OnTriggerExit(Collider other)
    {
        other.attachedRigidbody.isKinematic = false;
    }
   
}
