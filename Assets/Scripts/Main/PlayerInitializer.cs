using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.name = "PJS";
        PlayerManager.shovelForce = 1;
        PlayerManager.axForce = 1;
        PlayerManager.peakForce = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
