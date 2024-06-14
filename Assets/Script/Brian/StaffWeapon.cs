using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StaffWeapon : MonoBehaviour
{
    [Header("Weapon info")]
    public string _name;
    public string _description;
    public WeaponType _type;

    [Header("Weapon stats")]
    public float _damage;
    public float _speed;
    public float _weight;

    [Header("Weapon Effects")]
    public Transform _spawnLoc;
    public GameObject _magicSpawn;

    XRIDefaultInputActions input;
    InputAction triggerL;
    InputAction triggerR;

    private void Awake()
    {
        input = new XRIDefaultInputActions();

        OnDisable();
    }

    public void OnEnable()
    {
        input.Enable();

        triggerL = input.XRILeftHandInteraction.Activate;
        triggerR = input.XRIRightHandInteraction.Activate;

        triggerL.started += ShootMagic;
        triggerR.started += ShootMagic;
    }

    public void OnDisable()
    {
        input.Disable();

        triggerL.started -= ShootMagic;
        triggerR.started -= ShootMagic;
    }
                                                                                        
    public void ShootMagic(InputAction.CallbackContext context)
    {
        GameObject spawned = Instantiate(_magicSpawn, _spawnLoc.position, transform.rotation);

        spawned.GetComponent<Magic>()._damage = _damage;
        spawned.GetComponent<Rigidbody>().mass = _weight;
        spawned.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,_speed,0), ForceMode.Force);
    }
}
