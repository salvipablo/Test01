using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public new string name;
    public string type;
    public int quantity;

    public Item(int id, string name, string type, int quantity)
    {
        this.id = id;
        this.name = name;
        this.type = type;
        this.quantity = quantity;
    }
}
