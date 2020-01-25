using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input=0.3f * OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        Vector3 movement = new Vector3(input.x, 0, input.y);
        this.transform.Translate(movement);
    }
}
