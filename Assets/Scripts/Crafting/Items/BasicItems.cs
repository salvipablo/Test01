using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItems : MonoBehaviour 
{
    public void craftingWoodPlank()
    {
        for (int i = 0; i < 11; i++)
        {
            PlayerManager.createItem("Wood Plank", 1);
        }
    }
    
    public void craftingSticks() => PlayerManager.createItem("Wood Sticks", 3);
    public void craftTable() => Debug.Log("Mesa de crafteo");

    public void woodenShovel() => PlayerManager.createItem("Wooden Shovel", 1);

    public void woodenAx() => PlayerManager.createItem("Wooden Ax", 1);

    public void woodenPickaxe() => PlayerManager.createItem("Wooden Pickaxe", 1);
}
