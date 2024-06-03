using System.Collections;
using System.Collections.Generic;

using Unity.Mathematics;
using UnityEngine;

public class TestTargetRotation : MonoBehaviour
{
    public ConfigurableJoint[] joint;
    public Transform[] target;
    public float footHeight;
    public float timer;
    public float feetSpeed;
    public float phase,stoppingDistance,distance;
    public Transform player, pointofforceHand;
    public Rigidbody arm;
    public float streght;
    public Vector3 directionToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

        RotateTowardsPlayer();
        phase = Mathf.Sin(timer);
    }
    void FixedUpdate()
    {
        distance =Vector3.Distance(transform.position,player.position);
        timer += Time.fixedDeltaTime * feetSpeed;
        if(distance > stoppingDistance)
        {
            ////Upper Left Leg
            //Walking(joint[0], phase);
            //// Upper Right Leg
            //Walking(joint[1], -phase);
           
        }
        else
        {
           SlamTowardsPlayer(joint[4], phase);
           //SlamTowardsPlayer(joint[5], -phase);
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

        
        directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0;

       
        if (directionToPlayer != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * feetSpeed);
        }
    }

    public void SlamTowardsPlayer(ConfigurableJoint joint , float phaseSlam)
    {

        joint.targetRotation= pointofforceHand.localRotation;
    }
}
