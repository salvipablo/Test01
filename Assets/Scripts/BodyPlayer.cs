using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPlayer : MonoBehaviour
{
    private PlayerMovement iCanMove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) iCanMove = other.GetComponent<PlayerMovement>();
        if ( gameObject.tag.Equals("BodyPlayerFront") &&  other.gameObject.tag.Equals("Land")) iCanMove.itCanMoveForward = false;
        if (gameObject.tag.Equals("BodyPlayerBack") && other.gameObject.tag.Equals("Land")) iCanMove.itCanMoveBackwards = false;


    }

    private void OnTriggerExit(Collider other)
    {
        iCanMove.itCanMoveForward = true;
        iCanMove.itCanMoveBackwards = true;
    }
}
