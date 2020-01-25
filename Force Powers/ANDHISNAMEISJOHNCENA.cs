using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANDHISNAMEISJOHNCENA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("movable"))
        {
            other.GetComponent<Rigidbody>().useGravity = true;
            other.GetComponent<Rigidbody>().AddForce(new Vector3(0, -10, 0), ForceMode.Impulse);
        }
    }
}
