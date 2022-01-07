using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToLocation : MonoBehaviour
{
    
    //boolean variable used to determine if the object is currently being held by the player
    private bool grabbed;
    //Return true when the object is within the SnapZone zone
    private bool insideSnapZone;
    //Return true when the object has had it's location updated
    public bool snapped;
    //Set the specific part we want to snap to this location
    public GameObject InventoryItem;
    //Reference another object we can use to set rotation
    public GameObject SnapRotationReference;
    private OVRGrabbable _ovrGrabbable;

    // Detects when the RocketPark game object has entered the snap zone radius
    private void Awake()
    {
        _ovrGrabbable = InventoryItem.GetComponent<OVRGrabbable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == InventoryItem.name)
        {
            insideSnapZone = true; 
        }
    }
    
    //Detect when the RocketPart game object has left the snap zone radius
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == InventoryItem.name)
        {
            insideSnapZone = false; 
        }
    }
    
    //Check if the player has released the object AND if the object is within the SanpZone 
    //If both are true, sets the object location and rotation to the desired snap coordinates
    //Sets the public boolean Snapped to true for reference by SnapObject script
    void SnapObject()
    {
        if (grabbed == false && insideSnapZone == true)
        {
            InventoryItem.gameObject.transform.position = transform.position;
            InventoryItem.gameObject.transform.rotation = SnapRotationReference.transform.rotation;
            snapped = true;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        //Set grabbed to equal the boolean value "isGrabbed" from the OVRGrabbable script
        grabbed = _ovrGrabbable.isGrabbed;
        //Call our snap object script
        SnapObject();

    }
}
