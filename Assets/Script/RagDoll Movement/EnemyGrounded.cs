using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrounded : MonoBehaviour
{
    // Start is called before the first frame update
    public float distanceFromGround,raycastLenght,springStrengt;
    public LayerMask ground;
    public Transform positionenemy;
    public ConfigurableJoint[] joints;
    public BoxCollider[] colliders;
    public float treshHoldRagdoll;
    public Vector3[] originalPos;
    
    private JointDrive freeJointDrive = new JointDrive
    {
        positionSpring = 0,
        positionDamper = 0,
        maximumForce = float.MaxValue
        
    };
    void Start()
    {
        joints = GetComponentsInChildren<ConfigurableJoint>();
        
    }

    // Update is called once per frame
    void Update()
    {
        falling();
    }
    public void falling()
    {

        if (!IsGrounded())
        {
            for (int i = 0; i < joints.Length; i++)
            {
                joints[i].angularXDrive = freeJointDrive;
                joints[i].angularYZDrive = freeJointDrive;
                joints[i].xDrive = freeJointDrive;
                joints[i].yDrive = freeJointDrive;
                joints[i].zDrive = freeJointDrive;
            
            }
        }
        else
        {
            for (int i = 0; i < joints.Length; i++)
            {
                var driveX = joints[i].angularXDrive;
                var driveZY = joints[i].angularYZDrive;
                driveX.positionSpring = 10000;
                driveZY.positionSpring = 10000;
            }
        }
       
    }
    public bool IsGrounded()
    {
       RaycastHit hit;
       if(Physics.Raycast(positionenemy.position, Vector3.down,out hit,raycastLenght, ground))
        {
           
           distanceFromGround = Vector3.Distance(positionenemy.position,hit.point);   
            if(distanceFromGround> treshHoldRagdoll)
            {
                return false;
            }
        }
        return true;
    }
}
