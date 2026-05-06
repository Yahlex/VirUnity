using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryUI ui;
    public List<string> items = new List<string>();

    public void AddItem(string itemName)
    {
        items.Add(itemName);
        ui.ShowUSB();
        Debug.Log("Objet ajouté : " + itemName);
    }

    public bool HasItem(string itemName)
    {
        return items.Contains(itemName);
    }
}
