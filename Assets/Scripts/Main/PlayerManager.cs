using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public static Dictionary<string, int> itemsAndQuantities = new Dictionary<string, int>();

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

    public static void addQuantitiesOfItems(string nameItem, int amountToStore)
    {
        if (!PlayerManager.itemsAndQuantities.ContainsKey(nameItem)) PlayerManager.itemsAndQuantities.Add(nameItem, amountToStore);
        else PlayerManager.itemsAndQuantities[nameItem] += amountToStore;
    }

    public static void substractQuantitiesOfItems(string nameItem, int amountToStore)
    {
        PlayerManager.itemsAndQuantities[nameItem] -= amountToStore;
    }

    public static void storeItemInInventory(Item newItem, int amountToStore)
    {
        addQuantitiesOfItems(newItem.name, amountToStore);

        int posItemFound = 1;
        int posArraySearch = 0;

        while (amountToStore > 0)
        {
            posItemFound = PlayerManager.Inventory.FindIndex(posArraySearch, x => x.name.Equals(newItem.name));
            
            if (posItemFound != -1 && PlayerManager.Inventory[posItemFound].quantity < 5)
            {
                Debug.Log("Entro aca por que lo encontre pero quantity es menor a 5");
                int howManyCanISave = 5 - PlayerManager.Inventory[posItemFound].quantity;
                
                if (howManyCanISave >= amountToStore)
                {
                    PlayerManager.Inventory[posItemFound].quantity += amountToStore;
                    amountToStore = 0;
                } else
                {
                    PlayerManager.Inventory[posItemFound].quantity += howManyCanISave;
                    amountToStore -= howManyCanISave;
                }
            } else
            {
                if (posItemFound != -1 && PlayerManager.Inventory[posItemFound].quantity == 5)
                {
                    Debug.Log("Entro aca por que lo encontre pero quantity es igual a 5");
                    posArraySearch = posItemFound + 1;
                }
            }

            if (posItemFound == -1)
            {
                if (PlayerManager.Inventory.Count == 9) Debug.Log("No hay slot libre para almacenar este item: " + newItem.name);
                else
                {
                    Debug.Log("Entro aca porque no lo encontre y hay slots para crear o vacios");
                    amountToStore -= 1;

                    Item itemStore = PlayerManager.iThinkItem(newItem.id, newItem.name, newItem.type, 1, newItem.SpeedSwim, newItem.SpeedDisplacement,
                                                    newItem.SpeedShovel, newItem.SpeedAxe, newItem.SpeedPeak);
                    
                    posItemFound = PlayerManager.Inventory.FindIndex(posArraySearch, x => x.name.Equals("Empty"));

                    if (posItemFound != -1) PlayerManager.Inventory[posItemFound] = itemStore;
                    else PlayerManager.Inventory.Add(itemStore);
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
            if (PlayerManager.itemsAndQuantities.TryGetValue(necessaryMaterial.Key, out int value))
                if (value >= necessaryMaterial.Value) foundResources = true;
                else break;
        }
        return foundResources;
    }

    private static void stockControl(Dictionary<string, int> necessaryMaterials)
    {
        Item emptyNull = new Item(0, "Empty", "Empty", 0, 0, 0, 0, 0, 0, null, null);

        int posArraySearch = 0;

        foreach (KeyValuePair<string, int> necessaryMaterial in necessaryMaterials)
        {
            int amountToSubtract = necessaryMaterial.Value;

            substractQuantitiesOfItems(necessaryMaterial.Key, necessaryMaterial.Value);

            while (amountToSubtract > 0)
            {
                // Busco
                int PosItem = PlayerManager.Inventory.FindIndex(posArraySearch, x => x.name.Equals(necessaryMaterial.Key));

                if (PlayerManager.Inventory[PosItem].quantity >= amountToSubtract)
                {
                    PlayerManager.Inventory[PosItem].quantity -= amountToSubtract;
                    amountToSubtract = 0;
                }

                if (PlayerManager.Inventory[PosItem].quantity < amountToSubtract)
                {
                    amountToSubtract -= PlayerManager.Inventory[PosItem].quantity;
                    PlayerManager.Inventory[PosItem].quantity = 0;
                }

                if (PlayerManager.Inventory[PosItem].quantity <= 0) PlayerManager.Inventory[PosItem] = emptyNull;
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

            PlayerManager.storeItemInInventory(itemBuild, quantity);
        } else Debug.Log("No tiene los materiales suficientes para crear este item");
    }

    private static Item iThinkItem(int id, string name, string type, int quantity, float speedSwin, float speedDisplacement, float speedShovel, float speedAxe, float speedPeak)
    {
        return new Item(id, name, type, quantity, speedSwin, speedDisplacement, speedShovel, speedAxe, speedPeak, null, null);
    }
}
