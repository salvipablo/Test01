using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPlayer : MonoBehaviour
{
    private PlayerMovement iCanMove;

    private void OnTriggerEnter(Collider collidedObject)
    {
        //if (collidedObject.gameObject.tag.Equals("Player")) iCanMove = collidedObject.GetComponent<PlayerMovement>();

        //if (gameObject.tag.Equals("BodyPlayerFront") && !collidedObject.gameObject.tag.Equals("Player")) iCanMove.ItCanMoveForward = false;
        //if (gameObject.tag.Equals("BodyPlayerBack") && !collidedObject.gameObject.tag.Equals("Player")) iCanMove.ItCanMoveBackwards = false;
        //if (gameObject.tag.Equals("BodyPlayerRight") && !collidedObject.gameObject.tag.Equals("Player")) iCanMove.ItCanMoveRight = false;
        //if (gameObject.tag.Equals("BodyPlayerLeft") && !collidedObject.gameObject.tag.Equals("Player")) iCanMove.ItCanMoveLeft = false;
    }

    private void OnTriggerExit(Collider other)
    {
        //iCanMove.ItCanMoveForward = true;
        //iCanMove.ItCanMoveBackwards = true;
        //iCanMove.ItCanMoveRight = true;
        //iCanMove.ItCanMoveLeft = true;
    }
}
