using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.loadItemsForConstruction();

        Item emptyNull = new Item(0, "Empty", "Empty", 0, 0, 0, 0, 0, 0, null, null);
        PlayerManager.SettingCharacterStatesPerItem(emptyNull);
    }
}
