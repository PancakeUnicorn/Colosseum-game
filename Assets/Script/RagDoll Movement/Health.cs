using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    // Start is called before the first frame update
    public Rigidbody[] rigidbodies;
    public ConfigurableJoint[] joints;
    public float lifePoints;
    public HealthBodyParts[] bodyParts;
    public TestTargetRotation walking;
    public RotateArmTarget attack;
    public RotateTrap fireTrap;
    public Material burned;
    public bool alive;
    public List<GameObject> _spawnedParts;
    void Awake()
    {
        rigidbodies = gameObject.GetComponentsInChildren<Rigidbody>();
        joints = gameObject.GetComponentsInChildren<ConfigurableJoint>();
        bodyParts = gameObject.GetComponentsInChildren<HealthBodyParts>();
        walking = gameObject.GetComponent<TestTargetRotation>();
        attack= gameObject.GetComponentInChildren<RotateArmTarget>();
        fireTrap = GameObject.FindGameObjectWithTag("FireTrap").GetComponent<RotateTrap>();
        CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (fireTrap.onFire)
        {
            StartCoroutine(OnFire());
        }
       
     
        if(lifePoints <= 0 && !alive)
        {
            Death();
        }

        if (bodyParts[2].healthBodyPart <= 0)
        {
            Death();
        }
    }
    public float CalculateHealth()
    {
        lifePoints = 0;
        for (int i = 0; i < bodyParts.Length; i++)
        {
            HealthBodyParts bodypartScript = bodyParts[i].GetComponent<HealthBodyParts>();
            if(bodyParts != null)
            {
                lifePoints += bodypartScript.healthBodyPart;
            }
        }
        return lifePoints;
    }
    public void Death()
    {

        for (int i = 0;i < joints.Length;i++)
        {
            ConfigurableJoint joint = joints[i];
            if (joint != null)
            {
                JointDrive zeroDrive = new JointDrive();
                zeroDrive.positionDamper = 0;
                zeroDrive.positionSpring = 0;
                zeroDrive.maximumForce = 0;

                joint.angularXDrive = zeroDrive;
                joint.angularYZDrive = zeroDrive;
                joint.slerpDrive = zeroDrive;
                
                joint.xDrive = zeroDrive;
                joint.yDrive = zeroDrive;
                joint.zDrive = zeroDrive;

            }
        }
        for (int i = 0;i<rigidbodies.Length; i++)
        {
            rigidbodies[i].freezeRotation = false;
        }
        attack.enabled = false;
        walking.enabled = false;

        foreach (GameObject Obj in _spawnedParts)
        {
            Destroy destroyComponent = Obj.GetComponent<Destroy>();
            if(destroyComponent == null)
            {
                destroyComponent = Obj.AddComponent<Destroy>();
                destroyComponent._destroyDelay = 30;
            }
            
        }
        Destroy destroyEnemy = gameObject.GetComponent<Destroy>();

        if (destroyEnemy == null)
        {
            destroyEnemy = gameObject.AddComponent<Destroy>();
            destroyEnemy._destroyDelay = 30;
        }
        
        
    }
    public IEnumerator OnFire()
    {
        lifePoints -= 0.1f;


        yield return new WaitForSeconds(4f);

        
        fireTrap.onFire = false;
        fireTrap.fire.Stop();
        yield return null;
    }
}
