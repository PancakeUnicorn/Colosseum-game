using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public class TestTargetRotation : MonoBehaviour
{
    public ConfigurableJoint[] joint;
    public Transform[] target;
    public float footHeight;
    public float timer;
    public float feetSpeed;
    public float phase;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
       
       
        phase = Mathf.Sin(timer);
    }
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime * feetSpeed;
        //Upper Left Leg
        Walking(joint[0],phase );
        // Upper Right Leg

        Walking(joint[1],-phase );


    }
    public void Walking(ConfigurableJoint joint, float phase)
    {
        quaternion targetRotation = quaternion.Euler(new UnityEngine.Vector3(15f* phase,footHeight,0));
        joint.targetRotation =targetRotation;
    }
}
