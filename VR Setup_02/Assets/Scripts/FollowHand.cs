using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class FollowHand : MonoBehaviour
{
    public GameObject handObject;
    public float distanceOffset;
    public Vector3 offset; 
    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var targetPosition = handObject.transform.position;
        var forward = handObject.transform.forward;
        
        transform.position = Vector3.Lerp(transform.position, targetPosition +forward * distanceOffset, speed * Time.deltaTime);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(forward),speed  * Time.deltaTime);

    }
}
