using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCollectionAchieve : MonoBehaviour
{
    //Create array of game objects
    public GameObject[] InventoryItems;

    public GameObject goalAcheivePanel;
    //Used to check if all parts have been added to the inventory
    private bool partAdded;
    //Flag to ensure the items being collected in the inventory
    private bool launched = false;
    

    // Update is called once per frame
    void Update()
    {
        //Check if all three parts have been snapped into place, and make sure we haven't already launched
        if (fullyCollected() == true && launched == false)
        {
            goalAcheivePanel.SetActive(true);
        }
    }
    
    //Use forloop to iterate through the array of inventory items
    //Checks to see if isSnapped is set to true on each one
    //Return false if any one of the three is false
    //If all three return true, then set to true
    // ReSharper disable Unity.PerformanceAnalysis
    private bool fullyCollected()
    {
        for (int i= 0; i < InventoryItems.Length; i++)
        {
            partAdded = InventoryItems[i].GetComponent<SnapObject>().isSnapped;
            if (partAdded == false)
            {
                return false;
            }
            
        }

        return true;
    }
}
