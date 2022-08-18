using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItems : MonoBehaviour 
{
    public void craftingWoodPlank() => PlayerManager.createItem("Wood Plank", 10);
    
    public void craftingSticks() => PlayerManager.createItem("Wood Sticks", 3);

    public void craftTable() => Debug.Log("Mesa de crafteo");

    public void woodenShovel() => PlayerManager.createItem("Wooden Shovel", 1);

    public void woodenAx() => PlayerManager.createItem("Wooden Ax", 1);

    public void woodenPickaxe() => PlayerManager.createItem("Wooden Pickaxe", 1);

    public void stoneShovel() => PlayerManager.createItem("Stone Shovel", 1);

    public void stoneAx() => PlayerManager.createItem("Stone Ax", 1);

    public void stonePickaxe() => PlayerManager.createItem("Stone Pickaxe", 1);
}
