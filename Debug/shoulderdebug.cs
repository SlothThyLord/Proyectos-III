using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoulderdebug : MonoBehaviour
{
    public GameObject angle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TMPro.TextMeshPro text = this.gameObject.GetComponent<TMPro.TextMeshPro>();
        bool coso=angle.GetComponent<PRAISETHESUN>().isAscending();
        Transform hand = angle.GetComponent<PRAISETHESUN>().handpos();
        text.SetText("ascending:" + coso+" position Y"+hand.position.y);
    }
}
