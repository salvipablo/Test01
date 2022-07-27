using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerManager
{
    public static string name;  // Nombre.
    
    public static float Life;  // Vida.
    public static float Intelligence;  // Inteligencia.
    public static float Knock;  // Golpe.
    public static float Agility;  // Agilidad.
    public static float speedSwim;  // Nadar.
    public static float SpeedDisplacement;  // Caminar.
    public static float SpeedShovel;  // Pala.
    public static float SpeedAxe;  // Hacha.
    public static float SpeedPeak;  // Pico.

    public static List<Item> inventory = new List<Item>();

    public static void SettingCharacterStatesByDefault()
    {
        PlayerManager.name = "PJS";
        PlayerManager.speedSwim = 1;
        PlayerManager.SpeedDisplacement = 1;
        PlayerManager.SpeedShovel = 1;
        PlayerManager.SpeedAxe = 1;
        PlayerManager.SpeedPeak = 1;
    }
    public static void SettingCharacterStatesPerItem(Item item)
    {
        PlayerManager.speedSwim += item.SpeedSwim;
        PlayerManager.SpeedDisplacement += item.SpeedDisplacement;
        PlayerManager.SpeedShovel += item.SpeedShovel;
        PlayerManager.SpeedAxe += item.SpeedAxe;
        PlayerManager.SpeedPeak += item.SpeedPeak;
    }
}
