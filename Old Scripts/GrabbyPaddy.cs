using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbyPaddy : MonoBehaviour
{
    public GameObject CollidingObject;
    private int counter;
    public GameObject objectInHand;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5f || OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5f) && CollidingObject!=null)
        {
            print("I actually register clicks");
            counter++;
            if (counter % 2 == 1)
            {
                CollidingObject.transform.SetParent(gameObject.transform);
                CollidingObject.GetComponent<Rigidbody>().isKinematic = true;
            }
            else{
                CollidingObject.transform.SetParent(null);
                CollidingObject.GetComponent<Rigidbody>().isKinematic = false;
                CollidingObject = null;
            }

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponents<Rigidbody>()!=null)
        {
            print("I am grabbing something with a rigid body");
            CollidingObject = other.gameObject;
        }

    }
}
