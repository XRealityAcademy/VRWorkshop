using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory { get; private set; }

    private void Awake()
    {
       inventory = new List<InventoryItem>();
       m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
        

    }

    public void Add(InventoryItemData referenceData)
    {
      if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
         {
           // value.AddtoStack();
         }
      else
      {
         InventoryItem newItem = new InventoryItem(referenceData);
         inventory.Add(newItem);
         m_itemDictionary.Add(referenceData, newItem);
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
