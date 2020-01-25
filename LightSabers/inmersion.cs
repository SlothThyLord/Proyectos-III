using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inmersion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource w = this.gameObject.GetComponent<AudioSource>();
        if (this.gameObject.GetComponent<Rigidbody>().velocity.magnitude >=5)
        {
            if (!w.isPlaying)
            {
                w.Play();
            }
        }
    }
}
