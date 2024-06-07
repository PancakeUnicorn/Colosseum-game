using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArmTarget : MonoBehaviour
{
    //public float rotationSpeed;
    //public Vector3 direction;
    public Rigidbody attackPoint,shieldPoint;
    public float attackForce,blockForce,forceupArm;
    public Vector3 directionSwing,directionBlock;
    public GameObject player;
    public int attackType;
    public TestTargetRotation targetRotation;
    public GameObject mainObject;
    public bool isPreping;
    private Coroutine armUp;
    private Coroutine attack;
    // Start is called before the first frame update
    void Start()
    {
        targetRotation = mainObject.GetComponent<TestTargetRotation>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(targetRotation.distance < targetRotation.stoppingDistance)
        {
            if(attack == null)
            {
                attack = StartCoroutine(AttackTime());
            }
         
        }
        
        
    }
    void StartAttackShank()
    {
        directionSwing = attackPoint.transform.position - player.transform.position;
        attackPoint.AddForce(-directionSwing*attackForce,ForceMode.Impulse);
        Debug.Log("Attacked");
    }
    void BlockAttack()
    {
        directionBlock = shieldPoint.transform.position - player.transform.position;
        shieldPoint.AddForce(-directionBlock * blockForce,ForceMode.Impulse);
    }
    
   
    public IEnumerator PrepareAttacke()
    {
        while(isPreping)
        {
            attackPoint.AddForce(Vector3.up * forceupArm, ForceMode.Force);
            Debug.Log("isPreping");
            yield return null;
        
        }
    }
   
    public IEnumerator AttackTime()
    {
        isPreping = true;
        if(armUp == null)
        {
            armUp = StartCoroutine(PrepareAttacke());
        }
        yield return new WaitForSeconds(2f);
        isPreping = false;
        if(armUp != null)
        {
            StopCoroutine(PrepareAttacke());
            armUp = null;
        }
        
        StartAttackShank();
        yield return new WaitForSeconds(5);
        attack = null;
    }
}
