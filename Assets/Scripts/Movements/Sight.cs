using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    private LifeObject lifeObject;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (lifeObject != null) lifeObject.life -= 1;
        }
    }

    private void OnTriggerEnter(Collider collidedObject)
    {
        Debug.Log("Hubo colision contra: " + collidedObject.gameObject.tag);
        lifeObject = collidedObject.GetComponent<LifeObject>();
    }
}
