using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]

public class Inventory : MonoBehaviour
{
    public GameObject inventoryUI;

    public bool inventoryShown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Three))
        {
            inventoryShown = !inventoryShown;
            
            if(inventoryShown)
                inventoryUI.SetActive(true);
            else if(!inventoryShown)
                inventoryUI.SetActive(false);
        }
        
        

    }
}
