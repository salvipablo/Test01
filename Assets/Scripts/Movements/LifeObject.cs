using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeObject : MonoBehaviour
{
    public float life = 10;

    void Update()
    {
        if(life <= 0) Destroy(gameObject);
    }
}
