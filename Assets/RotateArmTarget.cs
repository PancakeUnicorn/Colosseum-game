using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArmTarget : MonoBehaviour
{
    //public float rotationSpeed;
    //public Vector3 direction;
    public Rigidbody attackPoint,shieldPoint;
    public float attackForce,blockForce;
    public Vector3 directionSwing,directionBlock;
    public GameObject player;
    public int attackType;
    public TestTargetRotation targetRotation;
    public GameObject mainObject;
    // Start is called before the first frame update
    void Start()
    {
        targetRotation = mainObject.GetComponent<TestTargetRotation>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //direction =  new Vector3 (1, 0, 0);
        //transform.Rotate (direction*rotationSpeed);
        if(Input.GetKeyDown(KeyCode.D))
        {
            StartAttackShank();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            BlockAttack();
        }
    }
    void StartAttackShank()
    {
        attackPoint.AddForce(directionSwing*attackForce,ForceMode.Impulse);
    }
    void BlockAttack()
    {
        directionBlock = shieldPoint.transform.position - player.transform.position;
        shieldPoint.AddForce(-directionBlock * blockForce,ForceMode.Impulse);
    }
    public IEnumerator AttackTime()
    {
        while(true)
        {
            attackType = Random.Range(0, 2);
            switch (attackType)
            {
                case 0:
                    StartAttackShank();
                    break;
                case 1:
                    BlockAttack(); 
                    break;
            }
            
            yield return new WaitForSeconds(5f);
            targetRotation.Attacking = false;
        }
    }
}
