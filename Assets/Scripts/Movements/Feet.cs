using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    private PlayerMovement iCanjump;

    private void OnTriggerEnter(Collider collidedObject)
    {
        if (collidedObject.gameObject.tag.Equals("Player")) iCanjump = collidedObject.GetComponent<PlayerMovement>();
        if (collidedObject.gameObject.tag.Equals("Land") || collidedObject.gameObject.tag.Equals("WoodenLog")) iCanjump.itCanJump = true;
    }
}
