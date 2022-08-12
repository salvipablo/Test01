using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInitializer : MonoBehaviour
{
    private float previousLife;  // Vida.
    private float previousLifeSpeedShovel;  // Pala.
    private float previousLifeSpeedAxe;  // Hacha.
    private float previousLifeSpeedPeak;  // Pico.

    public Text txt_1;
    public Text txt_2;
    public Text txt_3;
    public Text txt_4;

    public Text txtInvt_1;
    public Text txtInvt_2;
    public Text txtInvt_3;
    public Text txtInvt_4;
    public Text txtInvt_5;
    public Text txtInvt_6;
    public Text txtInvt_7;
    public Text txtInvt_8;


    // Start is called before the first frame update
    void Start()
    {
        this.previousLife = 0;
        this.previousLifeSpeedShovel = 0;
        this.previousLifeSpeedAxe = 0;
        this.previousLifeSpeedPeak = 0;

        this.txtInvt_1.text = "-";
        this.txtInvt_2.text = "-";
        this.txtInvt_3.text = "-";
        this.txtInvt_4.text = "-";
        this.txtInvt_5.text = "-";
        this.txtInvt_6.text = "-";
        this.txtInvt_7.text = "-";
        this.txtInvt_8.text = "-";

        PlayerManager.loadItemsForConstruction();

        Item emptyNull = new Item(0, "Empty", "Empty", 0, 0, 0, 0, 0, 0, null, null);
        PlayerManager.SettingCharacterStatesPerItem(emptyNull);
    }

    private void Update()
    {
        if (this.previousLife != PlayerManager.Life || this.previousLifeSpeedShovel != PlayerManager.SpeedShovel || 
            this.previousLifeSpeedAxe != PlayerManager.SpeedAxe || this.previousLifeSpeedPeak != PlayerManager.SpeedPeak) {
            this.txt_1.text = PlayerManager.Life.ToString();
            this.txt_2.text = PlayerManager.SpeedShovel.ToString();
            this.txt_3.text = PlayerManager.SpeedAxe.ToString();
            this.txt_4.text = PlayerManager.SpeedPeak.ToString();
        }

        //Debug.Log(PlayerManager.Inventory.Count);

        if (PlayerManager.Inventory.Count == 1) this.txtInvt_1.text = PlayerManager.Inventory[0].name;
        if (PlayerManager.Inventory.Count == 2) this.txtInvt_2.text = PlayerManager.Inventory[1].name;
        if (PlayerManager.Inventory.Count == 3) this.txtInvt_3.text = PlayerManager.Inventory[2].name;
        if (PlayerManager.Inventory.Count == 4) this.txtInvt_4.text = PlayerManager.Inventory[3].name;
        if (PlayerManager.Inventory.Count == 5) this.txtInvt_5.text = PlayerManager.Inventory[4].name;
        if (PlayerManager.Inventory.Count == 6) this.txtInvt_6.text = PlayerManager.Inventory[5].name;
        if (PlayerManager.Inventory.Count == 7) this.txtInvt_7.text = PlayerManager.Inventory[6].name;
        if (PlayerManager.Inventory.Count == 8) this.txtInvt_8.text = PlayerManager.Inventory[7].name;

    }
}
