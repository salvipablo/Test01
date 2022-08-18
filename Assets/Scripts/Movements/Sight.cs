using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Sight : MonoBehaviour
{
    private LifeObject lifeObject;
    private InfoItem infoItem;

    public GameObject objInventory;
    public GameObject objInsert;

    void Update()
    {
        if (Input.GetButtonDown("InsertCube")) insertCube();

        if (Input.GetButton("Fire2")) if (lifeObject != null) collectResource(lifeObject.gameObject.tag);

        if (Input.GetButtonDown("item_Inv1")) inventoryPositionChange(PlayerManager.Inventory[0]);
        if (Input.GetButtonDown("item_Inv2")) inventoryPositionChange(PlayerManager.Inventory[1]);
        if (Input.GetButtonDown("item_Inv3")) inventoryPositionChange(PlayerManager.Inventory[2]);
        if (Input.GetButtonDown("item_Inv4")) inventoryPositionChange(PlayerManager.Inventory[3]);
        if (Input.GetButtonDown("item_Inv5")) inventoryPositionChange(PlayerManager.Inventory[4]);
        if (Input.GetButtonDown("item_Inv6")) inventoryPositionChange(PlayerManager.Inventory[5]);
        if (Input.GetButtonDown("item_Inv7")) inventoryPositionChange(PlayerManager.Inventory[6]);
        if (Input.GetButtonDown("item_Inv8")) inventoryPositionChange(PlayerManager.Inventory[7]);

        if (Input.GetButtonDown("Caracter"))
        {
            Debug.Log("*** DATOS PERSONAJE ***");
            Debug.Log("Velocidad de Pala: " + PlayerManager.SpeedShovel);
            Debug.Log("Velocidad de Hacha: " + PlayerManager.SpeedAxe);
            Debug.Log("Velocidad de Pico: " + PlayerManager.SpeedPeak);
        }

        if (Input.GetButtonDown("Inventario")) showInventory();

        if (Input.GetButtonDown("Materials"))
        {
            clearConsole();

            foreach (KeyValuePair<string, int> item in PlayerManager.itemsAndQuantities)
            {
                Debug.Log(item.Key + " - " + item.Value);
            }
        }
    }

    private void OnTriggerEnter(Collider collidedObject)
    {
        lifeObject = collidedObject.GetComponent<LifeObject>();
        infoItem = collidedObject.GetComponent<InfoItem>();
    }

    private void inventoryPositionChange(Item selectedItem)
    {
        PlayerManager.SettingCharacterStatesPerItem(selectedItem);
    }

    private void collectResource(string resourceTag)
    {
        if (resourceTag.Equals("Land")) lifeObject.life -= PlayerManager.SpeedShovel;
        if (resourceTag.Equals("WoodenLog")) lifeObject.life -= PlayerManager.SpeedAxe;
        if (resourceTag.Equals("CStone")) lifeObject.life -= PlayerManager.SpeedPeak;

        if (lifeObject.life <= 0) collectedItem();
    }

    private void showInventory()
    {
        clearConsole();

        if (!objInventory.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            objInventory.SetActive(true);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            objInventory.SetActive(false);
        }

        for ( int j = 0; j < PlayerManager.Inventory.Count; j++ )
        {
            Debug.Log("Posicion del invetario (" + j + ")" + " - Item: " + PlayerManager.Inventory[j].name + " - Cantidad: " + PlayerManager.Inventory[j].quantity);
        }
    }

    private void collectedItem()
    {
        Item newItemInv = new Item(this.infoItem.id, this.infoItem.name, this.infoItem.type, 1,
                            this.infoItem.SpeedSwim, this.infoItem.SpeedDisplacement, this.infoItem.SpeedShovel,
                            this.infoItem.SpeedAxe, this.infoItem.SpeedPeak, null, null);
        
        PlayerManager.storeItemInInventory(newItemInv, 1);
        
        Destroy(this.infoItem.gameObject);
    }

    public void insertCube()
    {
        Vector3 originPosition = new Vector3(Mathf.Round(gameObject.transform.position.x), 
                                        Mathf.Round(gameObject.transform.position.y), 
                                        Mathf.Round(gameObject.transform.position.z));
        if ( thereIsCubeAside(originPosition)) Instantiate(this.objInsert, originPosition, new Quaternion(0,0,0,0));
    }

    public bool thereIsCubeAside(Vector3 originPosition)
    {
        RaycastHit hit;

        Vector3 direction = new Vector3(0, 0, 0);

        direction = new Vector3(0, 0, 0.6f);  // Adelante.
        if (Physics.Raycast(originPosition, direction, out hit, 1)) return true;
        
        direction = new Vector3(0, 0, -0.6f);  // Atras.
        if (Physics.Raycast(originPosition, direction, out hit, 1)) 
            if (!hit.collider.gameObject.tag.Equals("Player")) return true;

        direction = new Vector3(0.6f, 0, 0);  // Derecha.
        if (Physics.Raycast(originPosition, direction, out hit, 1)) return true;

        direction = new Vector3(-0.6f, 0, 0);  // Izquierda.
        if (Physics.Raycast(originPosition, direction, out hit, 1)) return true;

        direction = new Vector3(0, 0.6f, 0);  // Arriba.
        if (Physics.Raycast(originPosition, direction, out hit, 1)) return true;

        direction = new Vector3(0, -0.6f, 0);  // Abajo.
        if (Physics.Raycast(originPosition, direction, out hit, 1)) return true;

        return false;
    }

    private void clearConsole()
    {
        // Esto es para limpiar la consola
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
        // Esto es para limpiar la consola
    }
}
