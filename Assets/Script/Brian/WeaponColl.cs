using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponColl : MonoBehaviour
{
    public float _damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponentInParent<Health>().lifePoints -= _damage;
        }
    }
}
