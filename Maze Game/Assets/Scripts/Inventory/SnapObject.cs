using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapObject : MonoBehaviour
{
    //Reference the snap zone collider we'll be using
    public GameObject snapLocation;
    //Reference the game object that the snapped objects will become a part of
    public GameObject inventoryPanel;
    //Create a variable that will be used by the inventory collections to determine if all the pieces are being collected
    public bool isSnapped;
    //Boolean variable used to reference the "Snapped" boolean from the SnapToLocation script
    private bool objectSnapped;
    //Boolean variable used to determine if the object is currently being held by the player
    private bool grabbed;
    private OVRGrabbable _ovrGrabbable;
    private SnapToLocation _snapToLocation;
    private Rigidbody _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _ovrGrabbable = GetComponent<OVRGrabbable>();
        _snapToLocation = snapLocation.GetComponent<SnapToLocation>();
    }

    void Update()
    {
        //Set grabbed to equal the boolean value "isGrabbed" from the OVRGrabbable script
        grabbed = _ovrGrabbable.isGrabbed;
        //Set ObjectSnapped equal to the Snapped boolean from SnapToLocation
        objectSnapped = _snapToLocation.snapped;

       //Set object Rigidbody to be Kinematic after it has been snapped into position
        //Set the object to be the child of the Inventory object after it has been snapped
        //Set isSnapped variable to true to alert the InventoryGoalAchieve script
        if (objectSnapped == true)
        {
            _rigidbody.isKinematic = true;
            transform.SetParent(inventoryPanel.transform);
            isSnapped = true;

        }
        
        //Make sure that the object can still be grabbed by the OVRGrabber script. We get bugs without this.
        if (objectSnapped == false && grabbed == false)
        {
            _rigidbody.isKinematic = false;
        }

    }
}
