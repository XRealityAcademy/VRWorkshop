using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class InventoryItem : MonoBehaviour
{
    public InventoryItemData data { get; private set; }
    public int stackSize { get; private set; }

    public InventoryItem(InventoryItemData newData)
    {
        data = newData;
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
