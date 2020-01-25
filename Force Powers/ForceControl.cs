using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceControl : MonoBehaviour
{

    private bool rightHandActive;
    private bool leftHandActive;

    private float counter;

    void Start()
    {
        rightHandActive = false;
        leftHandActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.Touch) || OVRInput.Get(OVRInput.Button.SecondaryThumbstick, OVRInput.Controller.Touch))
        {
            this.GetComponent<Pull>().enabled = true;
            this.GetComponent<Push>().enabled = true;
            this.GetComponent<PRAISETHESUN>().enabled = true;
            this.GetComponent<smash>().enabled = true;
        }
        else
        {
            this.GetComponent<Pull>().enabled = false;
            this.GetComponent<Push>().enabled = false;
            this.GetComponent<PRAISETHESUN>().enabled = false;
            this.GetComponent<smash>().enabled = false;
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.Touch))
        {
            this.leftHandActive = true;
        }
        else
        {
            this.leftHandActive = false;
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstick, OVRInput.Controller.Touch))
        {
            this.rightHandActive = true;
        }
        else
        {
            this.rightHandActive = false;
        }
        
        

    }
    public bool isLeftHandActive()
    {
        return leftHandActive;
    }
    public bool isRightHandActive()
    {
        return rightHandActive;
    }
}

