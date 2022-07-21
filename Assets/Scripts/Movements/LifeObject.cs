using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeObject : MonoBehaviour
{
    public float life = 10;
    private InfoItem infoItem;

    private void Start()
    {
        infoItem = gameObject.GetComponent<InfoItem>();
    }

    void Update()
    {
        if(life <= 0)
        {
            bool encontrado = false;

            foreach (Item arrayItem in PlayerManager.inventory)
            {
                if (arrayItem.name.Equals(this.infoItem.name))
                {
                    encontrado = true;
                    arrayItem.quantity += 1;
                    break;
                }
            }

            if (!encontrado)
            {
                Item newItemInv = new Item(this.infoItem.id, this.infoItem.name, this.infoItem.type, 1);
                PlayerManager.inventory.Add(newItemInv);
            }

            Destroy(gameObject);
        }
    }
}
