using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id;
    public string name;
    public string type;
    public int quantity;
    public float SpeedSwim;  // Nadar
    public float SpeedDisplacement;  // Caminar
    public float SpeedShovel;  // Pala.
    public float SpeedAxe;  // Hacha.
    public float SpeedPeak;  // Pico.
    private string[] materials;
    private int[] amounts;


    public Item(int id, string name, string type, int quantity, float speedSwim, float speedDisplacement, 
                                    float speedShovel, float speedAxe, float speedPeak, string[] materials, int[] amounts)
    {
        this.id = id;
        this.name = name;
        this.type = type;
        this.quantity = quantity;
        this.SpeedSwim = speedSwim;
        this.SpeedDisplacement = speedDisplacement;
        this.SpeedShovel = speedShovel;
        this.SpeedAxe = speedAxe;
        this.SpeedPeak = speedPeak;
        this.materials = materials;
        this.amounts = amounts;
    }

    public string[] getMaterials()
    {
        return this.materials;
    }

    public int[] getAmounts()
    {
        return this.amounts;
    }
}
