using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kicking : MonoBehaviour
{
    public GameObject Kicker;
    public GameObject Foot;

    public float Foot_Forward_Force;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //The Foot instantiation happens here.
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Foot, Kicker.transform.position, Kicker.transform.rotation) as GameObject;

            //Sometimes Foot may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

            //Retrieve the Rigidbody component from the instantiated Foor and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            //Tell the Foot to be "pushed" forward by an amount set by Foot_Forward_Force. 
            Temporary_RigidBody.AddForce(transform.forward * Foot_Forward_Force);

            //Basic Clean Up, set the Foot to self destruct after x seconds
            Destroy(Temporary_Bullet_Handler, 0.1f);
        }
    }
}
