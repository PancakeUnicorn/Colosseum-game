using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonBack : MonoBehaviour
{
    
    public GameObject botAmount;
    public GameObject panelPickWeapon;


    public bool testPrevious;
 
   
    public void OnTriggerEnter(Collider other)
    {
        // previous button
        if (other.CompareTag("Left")  || other.CompareTag("Right"))
        {
            panelPickWeapon.SetActive(false);
            botAmount.SetActive(true);
        }
    }




}
