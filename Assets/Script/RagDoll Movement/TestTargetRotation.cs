using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class TestTargetRotation : MonoBehaviour
{
    public RotateArmTarget rotateArmTarget;
    public ConfigurableJoint[] joint;
    public Transform[] target;
    public float footHeight;
    public float timer;
    public float feetSpeed;
    public float phase,stoppingDistance,distance;
    public Transform pointofforceHand;
    public GameObject player;
    public Rigidbody arm;
    public float streght,rotationSlam;
    public Vector3 directionToPlayer;
    public bool Attacking;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("PlayerTarget");
        rotateArmTarget = pointofforceHand.GetComponent<RotateArmTarget>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        RotateTowardsPlayer();
        phase = Mathf.Sin(timer);
    }
    void FixedUpdate()
    {
        distance =Vector3.Distance(transform.position,player.transform.position);
        timer += Time.fixedDeltaTime * feetSpeed;
        if(distance > stoppingDistance)
        {
            ////Upper Left Leg
            Walking(joint[0], phase);
            //// Upper Right Leg
            Walking(joint[1], -phase);
           
        }
        

    }
    public void Walking(ConfigurableJoint joint, float phase)
    {
        quaternion targetRotation = quaternion.Euler(new UnityEngine.Vector3(15f* phase,footHeight,0));
        joint.targetRotation =targetRotation;
    }
    public void RotateTowardsPlayer()
    {
        
        if (player == null)
        { 
            return;
        }

        
        directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.y = 0; 

       
        if (directionToPlayer != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * feetSpeed);
        }
    }

 
}
