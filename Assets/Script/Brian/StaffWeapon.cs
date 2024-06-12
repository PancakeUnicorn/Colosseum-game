using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffWeapon : MonoBehaviour
{
    [Header("Weapon info")]
    public string _name;
    public string _description;
    public WeaponType _type;

    [Header("Weapon stats")]
    public float _damage;
    public float _sharpnes;
    public float _weight;

    [Header("Weapon Effects")]
    public GameObject _magicSpawn;
}
