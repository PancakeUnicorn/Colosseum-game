using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    public BaseWeapon _weapon;

    public LayerMask _enemyLayer;

    private void OnCollisionEnter(Collision collision)
    {
        _weapon._hitloc = collision.GetContact(0).point;
        _weapon.Hitcollider(collision.gameObject);
        _weapon.Hit(collision.collider);

        if(collision.gameObject.GetComponentInParent<RaggdollHit>())
        {
            _weapon.EnemyHit(collision.gameObject);

            RaggdollHit _raggdoll = collision.gameObject.GetComponentInParent<RaggdollHit>();

            //if (collision.collider == _raggdoll._weakPointsColl._head)
            //{
            //    _raggdoll._weakPointsBool._head = true;
            //}

            if (collision.collider == _raggdoll._weakPointsColl._armL)
            {
                _raggdoll._weakPointsBool._armL = true;
            }

            else if (collision.collider == _raggdoll._weakPointsColl._armR)
            {
                _raggdoll._weakPointsBool._armR = true;
            }

            else if (collision.collider == _raggdoll._weakPointsColl._leggL)
            {
                _raggdoll._weakPointsBool._leggL = true;
            }

            else if (collision.collider == _raggdoll._weakPointsColl._leggR)
            {
                _raggdoll._weakPointsBool._leggR = true;
            }
        }
    }
}
