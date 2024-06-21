using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoxingGloves : MonoBehaviour
{
    public InputActionProperty selectActionValueL;
    public InputActionProperty selectActionValueR;
    public GameObject glovesR,glovesL;
   
    public SkinnedMeshRenderer realHandsL,realHandsR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (selectActionValueL.action.ReadValue<float>() >= 0.1f)
        {
            if(other.CompareTag("Left") || other.CompareTag("Right") || other.CompareTag("Boxing"))
            {
                glovesL.SetActive(true);
                glovesR.SetActive(true);

                glovesL.GetComponent<PunchingPower>().enabled = true;
                glovesR.GetComponent<PunchingPower>().enabled = true;
                realHandsL.enabled = false;
                realHandsR.enabled = false;
            }
            
        }
    }
}
