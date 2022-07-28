using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItems : MonoBehaviour
{
    private int[,] stockToBeRemoved = new int[5, 2];

    private void Start()
    {
        stockToBeRemoved[0, 0] = 9999;
        stockToBeRemoved[1, 0] = 9999;
        stockToBeRemoved[2, 0] = 9999;
        stockToBeRemoved[3, 0] = 9999;
        stockToBeRemoved[4, 0] = 9999;
    }

    public void craftTable()
    {
        Debug.Log("Mesa de crafteo");
    }

    public void woodenShovel()  // Pala de madera
    {
        Dictionary<string, int> createWith = new Dictionary<string, int>();

        createWith.Add("Wood Plank", 3);
        createWith.Add("Wood Sticks", 2);

        bool itemsExists = canICreateItem(createWith);

        if (!itemsExists) Debug.Log("No tiene los materiales para fabricar el item");
        else
        {
            stockControl(this.stockToBeRemoved);

            Item itemInsert = new Item(5, "Wooden Shovel", "Shovel_Wooden", 1, 0, 0, 5, 0, 0);

            PlayerManager.storeItemInInventory(itemInsert);
        }
    }

    public void woodenAx()  // Hacha de madera.
    {
        Dictionary<string, int> createWith = new Dictionary<string, int>();

        createWith.Add("Wood Plank", 2);
        createWith.Add("Wood Sticks", 1);

        bool itemsExists = canICreateItem(createWith);

        if (!itemsExists) Debug.Log("No tiene los materiales para fabricar el item");
        else
        {
            stockControl(this.stockToBeRemoved);

            Item itemInsert = new Item(6, "Wooden Ax", "Ax_Wooden", 1, 0, 0, 0, 5, 0);

            PlayerManager.storeItemInInventory(itemInsert);
        }
    }

    public void woodenPickaxe()
    {
        Dictionary<string, int> createWith = new Dictionary<string, int>();

        createWith.Add("Wood Plank", 3);
        createWith.Add("Wood Sticks", 4);

        bool itemsExists = canICreateItem(createWith);

        if (!itemsExists) Debug.Log("No tiene los materiales para fabricar el item");
        else
        {
            stockControl(this.stockToBeRemoved);

            Item itemInsert = new Item(6, "Wooden Pickaxe", "Pickaxe_Wooden", 1, 0, 0, 0, 0, 5);

            PlayerManager.storeItemInInventory(itemInsert);
        }
    }

    private bool canICreateItem(Dictionary<string, int> necessaryMaterials)
    {
        bool foundResources = false;

        foreach ( KeyValuePair<string, int> necessaryMaterial in necessaryMaterials)
        {
            foundResources = false;

            for (int i = 0; i < PlayerManager.inventory.Count; i++)
            {
                if (PlayerManager.inventory[i].name.Equals(necessaryMaterial.Key) && PlayerManager.inventory[i].quantity >= necessaryMaterial.Value)
                {
                    stockToBeRemoved[i, 0] = i;
                    stockToBeRemoved[i, 1] = necessaryMaterial.Value;
                    foundResources = true;
                    break;
                }
            }

        }
        return foundResources;
    }

    private void stockControl(int[,] posToDeleteStock)
    {
        Debug.Log("Longitud de array de eliminacion" + posToDeleteStock.Length);
        for (int i = 0; i < posToDeleteStock.Length / 2; i++)
        {
            if (posToDeleteStock[i, 0] != 9999)
                    PlayerManager.inventory[posToDeleteStock[i, 0]].quantity -= posToDeleteStock[i, 1];
        }
    }
}
