using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEEET : MonoBehaviour
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
        if (other.gameObject.CompareTag("movable"))
        {
            Vector3 magicYeet = this.GetComponent<Rigidbody>().velocity;
            other.gameObject.GetComponent<Rigidbody>().AddForce(magicYeet*0.1f,ForceMode.Impulse);
        }
    }
}
