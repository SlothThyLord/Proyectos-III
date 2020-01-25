using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ready2play : MonoBehaviour
{
    public Transform position0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<Movement>().enabled)
        {
            if (!this.transform.position.Equals(position0.position))
            {
                this.gameObject.GetComponent<Rigidbody>().MovePosition(position0.position);
                this.transform.rotation = position0.rotation;
                this.gameObject.GetComponent<pewpew>().enabled = true;
            }
        }
    }
}
