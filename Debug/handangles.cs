using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handangles : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform coso;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<TMPro.TextMeshPro>().text = ""+coso.rotation.eulerAngles;
        
    }
}
