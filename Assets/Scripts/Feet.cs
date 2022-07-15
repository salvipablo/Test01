using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    private PlayerMovement iCanjump;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) iCanjump = other.GetComponent<PlayerMovement>();
        if (other.gameObject.tag.Equals("Land")) iCanjump.itCanJump = true;
    }
}
