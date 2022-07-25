using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerManager
{
    public static string name;
    public static int shovelForce;  // Pala.
    public static int axForce;  // Hacha.
    public static int peakForce;  // Pico.
    public static List<Item> inventory = new List<Item>();
}
