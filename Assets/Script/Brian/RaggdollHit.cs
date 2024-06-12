using UnityEngine;
using System;

public class RaggdollHit : MonoBehaviour
{
    public WeakPointsColl _weakPointsColl = new WeakPointsColl();
    public ExtraColl _extraColl = new ExtraColl();
    public WeakPointsObject _weakPointGameObect = new WeakPointsObject();
    public ObjectSpawn _objectSpawn = new ObjectSpawn();
    public WeakPointsBool _weakPointsBool = new WeakPointsBool();

    [Serializable]
    public class WeakPointsColl
    {
        public Collider _head;
        public Collider _armL;
        public Collider _armR;
        public Collider _leggL;
        public Collider _leggR;
    }

    [Serializable]
    public class ExtraColl
    {
        public Collider _armL;
        public Collider _armR;
        public Collider _leggL;
        public Collider _leggR;
    }

    [Serializable]
    public class WeakPointsObject
    {
        public GameObject _head;
        public GameObject _armL;
        public GameObject _weaponL;
        public GameObject _armR;
        public GameObject _weaponR;
        public GameObject _leggL;
        public GameObject _leggR;
    }

    [Serializable]
    public class ObjectSpawn
    {
        public GameObject _head;
        public GameObject _armL;
        public GameObject _weaponL;
        public GameObject _armR;
        public GameObject _weaponR;
        public GameObject _leggL;
        public GameObject _leggR;
    }

    [Serializable]
    public class WeakPointsBool
    {
        public bool _head;
        public bool _armL;
        public bool _armR;
        public bool _leggL;
        public bool _leggR;
    }

    private void FixedUpdate()
    {
        if (_weakPointsBool._head )
        {
            GameObject _obj = _weakPointGameObect._head;
            Destroy(_obj.GetComponentInChildren<SkinnedMeshRenderer>());
            Destroy(_obj.GetComponentInChildren<SkinnedMeshRenderer>());
            Destroy(_obj.GetComponent<SkinnedMeshRenderer>());

            GameObject Prefab = Instantiate(_objectSpawn._head, _obj.transform.position, _obj.transform.rotation);
            Prefab.AddComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().useDynamicAttach = true;
            Prefab.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().interactionLayers = 3;
            GetComponentInParent<Health>()._spawnedParts.Add(Prefab);

            _weakPointsBool._head = false;
        }

        if (_weakPointsBool._armL)
        {
            GameObject _obj = _weakPointGameObect._armL;
            Destroy(_weakPointsColl._armL);
            Destroy(_extraColl._armL);
            Destroy(_obj.GetComponent<SkinnedMeshRenderer>());

            if (_weakPointGameObect._weaponL)
            {
                Instantiate(_objectSpawn._weaponL, _weakPointGameObect._weaponL.transform.position, _weakPointGameObect._weaponL.transform.rotation);
                Destroy(_weakPointGameObect._weaponL);
            }

            GameObject Prefab = Instantiate(_objectSpawn._armL, _obj.transform.position, _obj.transform.rotation);
            Prefab.AddComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().useDynamicAttach = true;
            Prefab.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().interactionLayers = 3;
            GetComponentInParent<Health>()._spawnedParts.Add(Prefab);

            _weakPointsBool._armL = false;
        }

        if (_weakPointsBool._armR)
        {
            GameObject _obj = _weakPointGameObect._armR;
            Destroy(_weakPointsColl._armR.GetComponent<Collider>());
            Destroy(_extraColl._armR);
            Destroy(_obj.GetComponent<SkinnedMeshRenderer>());

            if (_weakPointGameObect._weaponR)
            {
                Instantiate(_objectSpawn._weaponR, _weakPointGameObect._weaponR.transform.position, _weakPointGameObect._weaponR.transform.rotation);
                Destroy(_weakPointGameObect._weaponR);
            }


            GameObject Prefab = Instantiate(_objectSpawn._armR, _obj.transform.position, _obj.transform.rotation);
            Prefab.AddComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().useDynamicAttach = true;
            Prefab.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().interactionLayers = 3;
            GetComponentInParent<Health>()._spawnedParts.Add(Prefab);

            _weakPointsBool._armR = false;
        }

        if (_weakPointsBool._leggL)
        {
            GameObject _obj = _weakPointGameObect._leggL;
            Destroy(_weakPointsColl._leggL.GetComponent<Collider>());
            Destroy(_extraColl._leggL);
            Destroy(_obj.GetComponent<SkinnedMeshRenderer>());

            GameObject Prefab = Instantiate(_objectSpawn._leggL, _obj.transform.position, _obj.transform.rotation);
            Prefab.AddComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().useDynamicAttach = true;
            Prefab.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().interactionLayers = 3;
            GetComponentInParent<Health>()._spawnedParts.Add(Prefab);

            _weakPointsBool._leggL = false;
        }

        if (_weakPointsBool._leggR)
        {
            GameObject _obj = _weakPointGameObect._leggR;
            Destroy(_weakPointsColl._leggR.GetComponent<Collider>());
            Destroy(_extraColl._leggR);
            Destroy(_obj.GetComponent<SkinnedMeshRenderer>());

            GameObject Prefab = Instantiate(_objectSpawn._leggR, _obj.transform.position, _obj.transform.rotation);
            Prefab.AddComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().useDynamicAttach = true;
            Prefab.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().interactionLayers = 3;
            GetComponentInParent<Health>()._spawnedParts.Add(Prefab);

            _weakPointsBool._leggR = false;
        }
    }
}