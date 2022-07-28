using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Sight : MonoBehaviour
{
    private LifeObject lifeObject;
    private InfoItem infoItem;

    void Update()
    {
        if (Input.GetButton("Fire2")) if (lifeObject != null) collectResource(lifeObject.gameObject.tag);

        if (Input.GetButton("item_Inv1")) inventoryPositionChange(PlayerManager.inventory[0]);
        if (Input.GetButton("item_Inv2")) inventoryPositionChange(PlayerManager.inventory[1]);
        if (Input.GetButton("item_Inv3")) inventoryPositionChange(PlayerManager.inventory[2]);
        if (Input.GetButton("item_Inv4")) inventoryPositionChange(PlayerManager.inventory[3]);
        if (Input.GetButton("item_Inv5")) inventoryPositionChange(PlayerManager.inventory[4]);
        if (Input.GetButton("item_Inv6")) inventoryPositionChange(PlayerManager.inventory[5]);

        if (Input.GetButtonDown("Inventario")) showInventory();

        if (Input.GetButtonDown("Informacion"))
        {
            Debug.Log("Velocidad de Pala:" + PlayerManager.SpeedShovel);
            Debug.Log("Velocidad de Hacha:" + PlayerManager.SpeedAxe);
            Debug.Log("Velocidad de pico:" + PlayerManager.SpeedPeak);
        }
    }

    private void OnTriggerEnter(Collider collidedObject)
    {
        lifeObject = collidedObject.GetComponent<LifeObject>();
        infoItem = collidedObject.GetComponent<InfoItem>();

        Debug.Log(infoItem);
    }

    private void inventoryPositionChange(Item selectedItem)
    {
        PlayerManager.SettingCharacterStatesByDefault();
        PlayerManager.SettingCharacterStatesPerItem(selectedItem);
    }

    private void collectResource(string resourceTag)
    {
        if (resourceTag.Equals("Land")) lifeObject.life -= PlayerManager.SpeedShovel;
        if (resourceTag.Equals("WoodenLog")) lifeObject.life -= PlayerManager.SpeedAxe;

        if (lifeObject.life <= 0) collectedItem();
    }

    private void showInventory()
    {

        // Esto es para limpiar la consola
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
        // Esto es para limpiar la consola


        foreach (Item item in PlayerManager.inventory)
        {
            Debug.Log(item.name + " - Cantidad: " + item.quantity);
        }
    }

    private void collectedItem()
    {
        Item newItemInv = new Item(this.infoItem.id, this.infoItem.name, this.infoItem.type, 1,
                            this.infoItem.SpeedSwim, this.infoItem.SpeedDisplacement, this.infoItem.SpeedShovel,
                            this.infoItem.SpeedAxe, this.infoItem.SpeedPeak);
        
        PlayerManager.storeItemInInventory(newItemInv);
        
        Destroy(this.infoItem.gameObject);
    }
}
