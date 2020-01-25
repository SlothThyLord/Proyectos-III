using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class RotateObject : MonoBehaviour
{
    public Text mensaje; 
    public GameObject cube;
    // Start is called before the first frame update
        

    public void RotateCube(float alfa, float beta, float gamma)
    {
           cube.transform.Rotate(new Vector3(alfa, beta, gamma) * Time.deltaTime);
            mensaje.text = Convert.ToString(alfa);
    }
}
