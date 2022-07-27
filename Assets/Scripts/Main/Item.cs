using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public new string name;
    public string type;
    public int quantity;
    public float SpeedSwim;  // Nadar
    public float SpeedDisplacement;  // Caminar
    public float SpeedShovel;  // Pala.
    public float SpeedAxe;  // Hacha.
    public float SpeedPeak;  // Pico.

    public Item(int id, string name, string type, int quantity, float speedSwim, float speedDisplacement, float speedShovel, float speedAxe, float speedPeak)
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
    }
}
