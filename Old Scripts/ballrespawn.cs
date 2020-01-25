using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballrespawn : MonoBehaviour
{
    public Transform originalPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(Transform postion)
    {
        this.originalPos = postion;
    }
    private void OnCollisionEnter(Collision collision)
    {
        this.transform.position = originalPos.position;
    }
}
