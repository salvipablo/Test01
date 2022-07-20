using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPlayer : MonoBehaviour
{
    private PlayerMovement iCanMove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) iCanMove = other.GetComponent<PlayerMovement>();

        if (gameObject.tag.Equals("BodyPlayerFront") && !other.gameObject.tag.Equals("Player")) iCanMove.ItCanMoveForward = false;
        if (gameObject.tag.Equals("BodyPlayerBack") && !other.gameObject.tag.Equals("Player")) iCanMove.ItCanMoveBackwards = false;
        if (gameObject.tag.Equals("BodyPlayerRight") && !other.gameObject.tag.Equals("Player")) iCanMove.ItCanMoveRight = false;
        if (gameObject.tag.Equals("BodyPlayerLeft") && !other.gameObject.tag.Equals("Player")) iCanMove.ItCanMoveLeft = false;
    }

    private void OnTriggerExit(Collider other)
    {
        iCanMove.ItCanMoveForward = true;
        iCanMove.ItCanMoveBackwards = true;
        iCanMove.ItCanMoveRight = true;
        iCanMove.ItCanMoveLeft = true;
    }
}
