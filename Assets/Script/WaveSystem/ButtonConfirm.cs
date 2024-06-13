using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonConfirm : MonoBehaviour
{
    public GameObject botAmount;
    public GameObject panelPickWeapon;
    public bool readyToSpawn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Left" || other.tag == "Right")
        {
            botAmount.SetActive(false);
            panelPickWeapon.SetActive(true);
            readyToSpawn = true;
        }
    }
}
