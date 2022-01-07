using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class FollowHand : MonoBehaviour
{
    //the hand to follow
    public GameObject handObject;
    //The distance between hand & the inventory panel
    public float distanceOffset;
    // the speed of the inventory panel follows the hand
    public float speed; 


    // Update is called once per frame
    void Update()
    {
        //get the hand position vector 3 as the target position 
        var targetPosition = handObject.transform.position;
        // get the hand forward vector 3
        var forward = handObject.transform.forward;
        //position: follow the "hand target position + forward * distanceOffset" in a certain speed
        transform.position = Vector3.Lerp(transform.position, targetPosition +forward * distanceOffset, speed * Time.deltaTime);
        //rotation: follow the "hand target rotation" 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(forward),speed  * Time.deltaTime);

    }
}
