using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpearScript : MonoBehaviour
{
    public Rigidbody enemyBody;
    public ConfigurableJoint joint;
    public InputActionProperty triggerL, triggerR;
    public GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (triggerL.action.IsPressed() || triggerR.action.IsPressed())
            {
                child = other.gameObject;
                child.transform.SetParent(transform, false);
                child.GetComponent<Rigidbody>().isKinematic = true;
                //enemyBody = other.gameObject.GetComponent<Rigidbody>();
                //joint.connectedBody = enemyBody;
            }
            else
            {
                child.GetComponent<Rigidbody>().isKinematic = false;
                child.transform.DetachChildren();
                //joint.connectedBody = null;
            }
        }
       
        
    }
}
