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
            if (lifeObject != null) lifeObject.life -= 1;
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
