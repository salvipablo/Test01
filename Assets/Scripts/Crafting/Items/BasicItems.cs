using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItems : MonoBehaviour
{
    public void craftTable()
    {
        Debug.Log("Mesa de crafteo");
    }

    public void woodenShovel()  // Pala de madera
    {
        string[] items = { "Wood Plank", "Wood Sticks" };
        int[] quantityItems = { 3, 2 };
        
        bool itemsExists = canICreateItem(items, quantityItems);

        if (itemsExists)
        {
            Item itemInsert = new Item(3, "Wooden Shovel", "Shovel_Wooden", 1, 5);

            itemsExists = false;

            foreach (Item item in PlayerManager.inventory)
            {
                if (item.name.Equals("Wooden Shovel"))
                {
                    item.quantity += itemInsert.quantity;
                    itemsExists = true;
                }
            }

            if (!itemsExists) PlayerManager.inventory.Add(itemInsert);
        }
        else
        {
            Debug.Log("No tiene los elementos para crear una pala de madera");
        }
    }

    public void woodenAx()
    {
        Debug.Log("Hacha de madera");
    }

    public void woodenPickaxe()
    {
        Debug.Log("Pico de madera");
    }

    public bool canICreateItem(string[] necessaryItems, int[] quantitiesNeeded)
    {
        bool resourceFound = false;

        for (int i = 0; i < necessaryItems.Length; i++)
        {
            foreach (Item itemInv in PlayerManager.inventory)
            {
                if (itemInv.name.Equals(necessaryItems[i]) && itemInv.quantity > 0)
                {
                    itemInv.quantity -= quantitiesNeeded[i];
                    if (itemInv.quantity == 0) PlayerManager.inventory.Remove(itemInv);
                    resourceFound = true;
                    break;
                }
            }
        }

        return resourceFound;
    }
}