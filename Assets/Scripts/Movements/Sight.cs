using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    private LifeObject lifeObject;
    private Item item;

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
        item = collidedObject.GetComponent<Item>();
    }

    private void inventoryPositionChange(Item selectedItem)
    {
        PlayerManager.SettingCharacterStatesByDefault();
        PlayerManager.SettingCharacterStatesPerItem(selectedItem);
    }

    private void collectResource(string resourceTag)
    {
        if (resourceTag.Equals("Land")) lifeObject.life -= PlayerManager.SpeedShovel;
        if (resourceTag.Equals("Wood")) lifeObject.life -= PlayerManager.SpeedAxe;
    }

    private void showInventory()
    {
        foreach (Item item in PlayerManager.inventory)
        {
            Debug.Log(item.name + " - Cantidad: " + item.quantity);
        }
    }
}
