using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerManager
{
    public static string name;  // Nombre.
    
    public static float Life;  // Vida.
    public static float Intelligence;  // Inteligencia.
    public static float Knock;  // Golpe.
    public static float Agility;  // Agilidad.
    public static float speedSwim;  // Nadar.
    public static float SpeedDisplacement;  // Caminar.
    public static float SpeedShovel;  // Pala.
    public static float SpeedAxe;  // Hacha.
    public static float SpeedPeak;  // Pico.

    public static List<Item> Inventory = new List<Item>();
    public static List<Item> Items = new List<Item>();

    public static void SettingCharacterStatesPerItem(Item item)
    {
        PlayerManager.speedSwim = 1 + item.SpeedSwim;
        PlayerManager.SpeedDisplacement = 1 + item.SpeedDisplacement;
        PlayerManager.SpeedShovel = 1 + item.SpeedShovel;
        PlayerManager.SpeedAxe = 1 + item.SpeedAxe;
        PlayerManager.SpeedPeak = 1 + item.SpeedPeak;
    }

    public static void loadItemsForConstruction()
    {
        Items.Add(new Item(1, "Common Land", "Land_Common", 0, 0, 0, 0, 0, 0, null, null));  // Tierra comun.
        Items.Add(new Item(1, "Wooden Log", "Log_Wooden", 0, 0, 0, 0, 0, 0, null, null));  // Tronco de madera.
        Items.Add(new Item(1, "Wood Plank", "Plank_Wood", 0, 0, 0, 0, 0, 0, new string[] { "Wooden Log" }, new int[] { 1 }));  // Tabla de madera.
        Items.Add(new Item(1, "Wood Sticks", "Sticks_Wood", 0, 0, 0, 0, 0, 0, new string[] { "Wood Plank" }, new int[] { 1 }));  // Palito.
        Items.Add(new Item(1, "Wooden Shovel", "Shovel_Wooden", 0, 0, 0, 5, 0, 0, new string[] { "Wood Plank", "Wood Sticks" }, new int[] { 3, 2 }));  // Pala de madera.
        Items.Add(new Item(1, "Wooden Ax", "Ax_Wooden", 0, 0, 0, 0, 5, 0, new string[] { "Wood Plank", "Wood Sticks" }, new int[] { 2, 1 }));  // Hacha de madera.
        Items.Add(new Item(1, "Wooden Pickaxe", "Pickaxe_Wooden", 0, 0, 0, 0, 0, 5, new string[] { "Wood Plank", "Wood Sticks" }, new int[] { 3, 4 }));  // Pico de madera.
    }

    public static void storeItemInInventory(Item newItem, int amountToStore)
    {
        int posItemFound = 1;
        int posArraySearch = 0;

        for (int i = 0; i < amountToStore; i++)
        {
            posItemFound = PlayerManager.Inventory.FindIndex(posArraySearch, x => x.name.Equals(newItem.name));
            
            if (posItemFound != -1)
            {
                Debug.Log("Quantity de newItem: " + newItem.quantity);

                if (PlayerManager.Inventory[posItemFound].quantity < 5) PlayerManager.Inventory[posItemFound].quantity += 1;
                else
                {
                    posArraySearch = posItemFound + 1;
                    posItemFound = -1;
                }
            }

            if (posItemFound == -1)
            {
                if (PlayerManager.Inventory.Count == 8) Debug.Log("No hay slot libre para almacenar este item: " + newItem.name);
                else
                {
                    if ( newItem.quantity > 1) newItem.quantity = 1;
                    PlayerManager.Inventory.Add(newItem);
                }
            }
        }
    }

    private static bool canICreateItem(Dictionary<string, int> necessaryMaterials)
    {
        bool foundResources = false;

        foreach (KeyValuePair<string, int> necessaryMaterial in necessaryMaterials)
        {
            foundResources = false;

            for (int i = 0; i < PlayerManager.Inventory.Count; i++)
            {
                if (PlayerManager.Inventory[i].name.Equals(necessaryMaterial.Key) && PlayerManager.Inventory[i].quantity >= necessaryMaterial.Value)
                {
                    foundResources = true;
                    break;
                }
            }

            if (!foundResources) break;
        }

        return foundResources;
    }

    private static void stockControl(Dictionary<string, int> necessaryMaterials)
    {
        Item emptyNull = new Item(0, "Empty", "Empty", 0, 0, 0, 0, 0, 0, null, null);

        foreach (KeyValuePair<string, int> necessaryMaterial in necessaryMaterials)
        {
            int PosItem = PlayerManager.Inventory.FindIndex(x => x.name.Equals(necessaryMaterial.Key));
            Debug.Log("Posicion donde encontro el item:" + PosItem);
            if (PosItem != -1)
            {
                PlayerManager.Inventory[PosItem].quantity -= necessaryMaterial.Value;
                if (PlayerManager.Inventory[PosItem].quantity <= 0.0) PlayerManager.Inventory[PosItem] = emptyNull;
            }
        }
    }

    public static void createItem(string nameOfItemToCreate, int quantity)
    {
        Item itemBuild = PlayerManager.Items.Find(x => x.name.Equals(nameOfItemToCreate));

        Dictionary<string, int> createWith = new Dictionary<string, int>();
        for (int i = 0; i < itemBuild.getMaterials().Length; i++)
        {
            createWith.Add(itemBuild.getMaterials()[i], itemBuild.getAmounts()[i]);
        }
        bool canICreateThisMeterial = PlayerManager.canICreateItem(createWith);

        if (canICreateThisMeterial)
        {
            stockControl(createWith);

            Item newItem = new Item(itemBuild.id, itemBuild.name, itemBuild.type, 1, itemBuild.SpeedSwim, itemBuild.SpeedDisplacement,
                                        itemBuild.SpeedShovel, itemBuild.SpeedAxe, itemBuild.SpeedPeak, null, null);

            PlayerManager.storeItemInInventory(newItem, quantity);
        } else Debug.Log("No tiene los materiales suficientes para crear este item");
    }
}
