using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class Gloves : MonoBehaviour
{
    public GameObject handsR;
    public GameObject handsL;
    public GameObject boxingL;
    public GameObject boxingR;
    public InputActionProperty leftSelectValue;
    public InputActionProperty rightSelectValue;
    private void Update()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boxing"))
        {
          
            if (leftSelectValue.action.IsPressed())
            {
                //boxingL.transform.position = handsL.transform.position;
            }
            else if (rightSelectValue.action.IsPressed())
            {
                //boxingR.transform.position = handsR.transform.position;
                
            }
        }
        

    }
}
