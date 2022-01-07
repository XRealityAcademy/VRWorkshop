using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public OVRGrabbable HeldObject;
    void OnTriggerEnter(Collider other)
    {
        var Grabbable = other.gameObject.GetComponent<OVRGrabbable>();
        if (Grabbable != null && Grabbable.isGrabbed)
        {
            HeldObject = Grabbable;
        }
    }

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
