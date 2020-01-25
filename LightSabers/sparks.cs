using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparks : MonoBehaviour
{
    public GameObject spark;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject sparkly = Instantiate(spark, other.transform.position,this.transform.rotation);
        sparkly.GetComponent<ParticleSystem>().Play();
        Destroy(sparkly, 0.2f);
    }

}
