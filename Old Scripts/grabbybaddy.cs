using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbybaddy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject body;
    public GameObject CollidingObject;
    public GameObject objectInHand;
    private float distance;
    private float phi;

    void Start()
    {
        Vector3 pos=transform.position;
        Vector3 pos1 = body.transform.position;
        distance = (pos.x - pos1.x)* (pos.x - pos1.x) + (pos.y - pos1.y)* (pos.y - pos1.y);
        phi = Mathf.Atan((pos.y - pos1.y)/ (pos.x - pos1.x));
    }

    // Update is called once per frame

    //hay que cambiar el .GETAxis por el OVRINput.GET(OVRInput.Axis2d.primaryIndexSelector)
    //luego hay que cambiar la detección a continua para que funcione bien el script.
    void Update()
    {
        /*float yRotation = body.transform.localRotation.y;
        this.phi += yRotation;
        float x = body.transform.position.x + distance * Mathf.Cos(phi);
        float y = body.transform.position.y + distance * Mathf.Sin(phi);
        Vector3 position = new Vector3(x, 0, y);
        this.transform.Translate(position);*/
        if ((OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.2f) && CollidingObject)
        {
            GrabObject();
        }

        if ((OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) < 0.2f) && objectInHand)
        {
            ReleaseObject();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (objectInHand == null)
        {
            CollidingObject = other.gameObject;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        CollidingObject = null;
        
    }
    private void GrabObject()
    {
        try
        {
            objectInHand = CollidingObject;
            objectInHand.transform.SetParent(this.GetComponentInParent<Transform>());
            objectInHand.GetComponent<Rigidbody>().isKinematic = true;
        }catch(UnityException e)
        {
            print(e);
        }
        
    }
    private void ReleaseObject()
    {
        objectInHand.GetComponent<Rigidbody>().isKinematic = false;
        objectInHand.transform.SetParent(null);
        objectInHand = null;
    }

}

