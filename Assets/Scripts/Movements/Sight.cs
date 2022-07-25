using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    private LifeObject lifeObject;
    private Item item;

    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            if (lifeObject != null) lifeObject.life -= PlayerManager.shovelForce;
        }

        if (Input.GetButton("item_Inv1"))
        {
            PlayerManager.shovelForce += PlayerManager.inventory[0].shovelForce;
        }

        if (Input.GetButton("item_Inv2"))
        {
            PlayerManager.shovelForce += PlayerManager.inventory[1].shovelForce;
        }

        if (Input.GetButton("item_Inv3"))
        {
            PlayerManager.shovelForce += PlayerManager.inventory[2].shovelForce;
        }

        if (Input.GetButton("item_Inv4"))
        {
            PlayerManager.shovelForce += PlayerManager.inventory[3].shovelForce;
        }

        if (Input.GetButton("item_Inv5"))
        {
            PlayerManager.shovelForce += PlayerManager.inventory[4].shovelForce;
        }

        if (Input.GetButton("item_Inv6"))
        {
            PlayerManager.shovelForce += PlayerManager.inventory[5].shovelForce;
        }

        if (Input.GetButtonDown("Inventario"))
        {
            foreach (Item item in PlayerManager.inventory)
            {
                Debug.Log(item.name + " - Cantidad: " + item.quantity);
            }
        }
    }

    private void OnTriggerEnter(Collider collidedObject)
    {
        lifeObject = collidedObject.GetComponent<LifeObject>();
        item = collidedObject.GetComponent<Item>();
    }
}
