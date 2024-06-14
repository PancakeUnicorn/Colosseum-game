using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public float _damage;

    public bool _fire;
    public Material _iceMaterial;

    public GameObject _hitSpawn;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponentInParent<Health>().lifePoints -= _damage;

            if (_fire)
            {
                //collision.gameObject.GetComponentInParent<Rigidbody>().AddExplosionForce(50,)

                ParticleSystem fire = collision.gameObject.GetComponentInParent<TestTargetRotation>().GetComponentInChildren<ParticleSystem>();
                if (fire != null)
                {
                    fire.Play();
                }
            }

            else
            {
                collision.gameObject.GetComponentInParent<RaggdollHit>()._weakPointGameObect._head.GetComponent<SkinnedMeshRenderer>().materials[1].SetColor("_EmissionColor", Color.clear);
                collision.gameObject.GetComponentInParent<RaggdollHit>()._weakPointGameObect._armL.GetComponent<SkinnedMeshRenderer>().materials[1].SetColor("_EmissionColor", Color.clear);
                collision.gameObject.GetComponentInParent<RaggdollHit>()._weakPointGameObect._armR.GetComponent<SkinnedMeshRenderer>().materials[1].SetColor("_EmissionColor", Color.clear);
                collision.gameObject.GetComponentInParent<RaggdollHit>()._weakPointGameObect._leggL.GetComponent<SkinnedMeshRenderer>().materials[1].SetColor("_EmissionColor", Color.clear);
                collision.gameObject.GetComponentInParent<RaggdollHit>()._weakPointGameObect._leggR.GetComponent<SkinnedMeshRenderer>().materials[1].SetColor("_EmissionColor", Color.clear);
            }
        }

        Instantiate(_hitSpawn, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
