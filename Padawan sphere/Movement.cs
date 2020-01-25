using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Vector3 v;

    // Start is called before the first frame update
    void Start()
    {
        v = new Vector3(2.0f, 0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(v, Vector3.up,5 *Time.deltaTime);
    }

}
