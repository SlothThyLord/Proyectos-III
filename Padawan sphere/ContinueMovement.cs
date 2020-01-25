using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueMovement : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Movement>().enabled = true;
        this.gameObject.GetComponent<pewpew>().enabled = false;
    }
}
