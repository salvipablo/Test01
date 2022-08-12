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
        Items.Add(new Item(1, "Wood Plank", "Plank_Wood", 0, 0, 0, 0, 0, 0, new string[] { "Wooden Log" }, new float[] { 0.1f }));  // Tabla de madera.
        Items.Add(new Item(1, "Wood Sticks", "Sticks_Wood", 0, 0, 0, 0, 0, 0, new string[] { "Wood Plank" }, new float[] { 1 }));  // Palito.
        Items.Add(new Item(1, "Wooden Shovel", "Shovel_Wooden", 0, 0, 0, 5, 0, 0, new string[] { "Wood Plank", "Wood Sticks" }, new float[] { 3, 2 }));  // Pala de madera.
        Items.Add(new Item(1, "Wooden Ax", "Ax_Wooden", 0, 0, 0, 0, 5, 0, new string[] { "Wood Plank", "Wood Sticks" }, new float[] { 2, 1 }));  // Hacha de madera.
        Items.Add(new Item(1, "Wooden Pickaxe", "Pickaxe_Wooden", 0, 0, 0, 0, 0, 5, new string[] { "Wood Plank", "Wood Sticks" }, new float[] { 3, 4 }));  // Pico de madera.
    }

    public static void storeItemInInventory(Item newItem)
    {

        int posItemFound = 1;
        int posArraySearch = 0;

        while (posItemFound != -1)
        {
            posItemFound = PlayerManager.Inventory.FindIndex(posArraySearch, x => x.name.Equals(newItem.name));

            if (posItemFound != -1)
            {
                if (PlayerManager.Inventory[posItemFound].quantity < 5)
                {
                    PlayerManager.Inventory[posItemFound].quantity += 1;
                    break;
                } else posArraySearch = posItemFound + 1;
            }
        }

        if (posItemFound == -1)
        {
            if (PlayerManager.Inventory.Count == 8) Debug.Log("No hay slot libre para almacenar este item: " + newItem.name);
            else PlayerManager.Inventory.Add(newItem);
        }
    }

    private static bool canICreateItem(Dictionary<string, float> necessaryMaterials)
    {
        bool foundResources = false;

        foreach (KeyValuePair<string, float> necessaryMaterial in necessaryMaterials)
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

    private static void stockControl(Dictionary<string, float> necessaryMaterials)
    {
        Item emptyNull = new Item(0, "Empty", "Empty", 0, 0, 0, 0, 0, 0, null, null);

        foreach (KeyValuePair<string, float> necessaryMaterial in necessaryMaterials)
        {
            int PosItem = PlayerManager.Inventory.FindIndex(x => x.name.Equals(necessaryMaterial.Key));

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

        Dictionary<string, float> createWith = new Dictionary<string, float>();
        for (int i = 0; i < itemBuild.getMaterials().Length; i++)
        {
            createWith.Add(itemBuild.getMaterials()[i], itemBuild.getAmounts()[i]);
        }

        bool canICreateThisMeterial = PlayerManager.canICreateItem(createWith);

        if (canICreateThisMeterial)
        {
            stockControl(createWith);

            Item newItem = new Item(itemBuild.id, itemBuild.name, itemBuild.type, quantity, itemBuild.SpeedSwim, itemBuild.SpeedDisplacement,
                                        itemBuild.SpeedShovel, itemBuild.SpeedAxe, itemBuild.SpeedPeak, null, null);

            PlayerManager.storeItemInInventory(newItem);
        } else
        {
            Debug.Log("No tiene los materiales suficientes para crear este item");
        }
    }
}
