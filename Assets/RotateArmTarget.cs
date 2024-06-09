using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArmTarget : MonoBehaviour
{
    
    public Rigidbody attackPoint,shieldPoint;
    public Transform handSword;
    public float attackForce,blockForce,forceupArm;
    public Vector3 directionSwing,directionBlock;
    public GameObject player;
    public int attackType;
    public TestTargetRotation targetRotation;
    public GameObject mainObject;
    public bool isPreping;
    public bool hasAttacked;
    public EnemyState currentState;
    public enum EnemyState
    {
        Walking,
        PrepareAttack,
        Attacking,
        Blocking
    }
    // Start is called before the first frame update
    void Start()
    {
        targetRotation = mainObject.GetComponent<TestTargetRotation>();
        player = GameObject.FindWithTag("Player");
        currentState = EnemyState.Walking;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Walking:
                UpdateWalking();
                break;
            case EnemyState.PrepareAttack:
                StartCoroutine(UpdatePrepareAttack());
                break;
            case EnemyState.Attacking:
                UpdateAttacking();
                break;

        }

    }
    void UpdateWalking()
    {
        PrepareAttacke();
        if(targetRotation.distance<=targetRotation.stoppingDistance)
        {
            currentState = EnemyState.PrepareAttack;
        }
    }
    void UpdateAttacking()
    {
        PerformAttack();
        currentState = EnemyState.Walking;
    }
    void PerformAttack()
    {
        directionSwing = attackPoint.transform.position - player.transform.position;
        attackPoint.AddForce(-directionSwing*attackForce,ForceMode.Impulse);
        
        
    }
    void BlockAttack()
    {
        directionBlock = shieldPoint.transform.position - player.transform.position;
        shieldPoint.AddForce(-directionBlock * blockForce,ForceMode.Impulse);
    }
    
   IEnumerator UpdatePrepareAttack()
    {
        PrepareAttacke();
        yield return new WaitForSeconds(2);
        currentState = EnemyState.Attacking;
    }
    public void PrepareAttacke()
    {
        shieldPoint.AddForce(Vector3.up*forceupArm,ForceMode.Force);
        attackPoint.AddForce(Vector3.up* forceupArm, ForceMode.Force);
          
        
    }
   
}
