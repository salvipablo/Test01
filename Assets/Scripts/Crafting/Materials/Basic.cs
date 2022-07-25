using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : MonoBehaviour
{
    public void craftingWood()
    {
        bool itemExists = false;

        // Tengo que tener 1 de Common Wood
        foreach (Item item in PlayerManager.inventory)
        {
            if (item.name.Equals("Common Wood") && item.quantity > 0)
            {
                itemExists = true;
                item.quantity -= 1;
                if (item.quantity == 0) PlayerManager.inventory.Remove(item);
                break;
            }

            
        }

        if (itemExists)
        {
            Item itemInsert = new Item(3, "Wood Plank", "Plank_Wood", 10);

            itemExists = false;

            foreach (Item item in PlayerManager.inventory)
            {
                if (item.name.Equals("Wood Plank"))
                {
                    item.quantity += itemInsert.quantity;
                    itemExists = true;
                }
            }

            if (!itemExists) PlayerManager.inventory.Add(itemInsert);
        }
        else
        {
            Debug.Log("No tiene madera comun para crear tabla de madera");
        }
    }

    public void craftingSticks()
    {
        bool itemExists = false;

        // Tengo que tener 1 de Common Wood
        foreach (Item item in PlayerManager.inventory)
        {
            if (item.name.Equals("Wood Plank") && item.quantity > 0)
            {
                itemExists = true;
                item.quantity -= 1;
                if (item.quantity == 0) PlayerManager.inventory.Remove(item);
                break;
            }


        }

        if (itemExists)
        {
            Item itemInsert = new Item(3, "Wood Sticks", "Sticks_Wood", 3);

            itemExists = false;

            foreach (Item item in PlayerManager.inventory)
            {
                if (item.name.Equals("Wood Sticks"))
                {
                    item.quantity += itemInsert.quantity;
                    itemExists = true;
                }
            }

            if (!itemExists) PlayerManager.inventory.Add(itemInsert);
        }
        else
        {
            Debug.Log("No tiene tablas de madera para crear palitos");
        }
    }
}
