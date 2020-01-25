using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullRev : MonoBehaviour
{
    public Transform Lhand;
    public Transform Rhand;
    public GameObject helper;
    public AudioSource sEffect;

    private float Yref;
    private float Yheight;
    private bool ack;
    private GameObject clone;

    void Start()
    {
        ack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<ForceControl>().isLeftHandActive())
        {
            LhandPush();
        }
        if (this.GetComponent<ForceControl>().isRightHandActive())
        {
            RhandPush();
        }
    }
    private void LhandPush()
    {
        if ((Lhand.rotation.eulerAngles.z > 130 && Lhand.rotation.eulerAngles.z < 170) && ack == false && Lhand.rotation.eulerAngles.x>130)
        {
            Yref = Lhand.rotation.eulerAngles.y;
            Yheight = Lhand.position.y;
            ack = true;
            clone = Instantiate(helper, Lhand);
            clone.transform.Translate(new Vector3(0, 2.5f, 0));
            clone.transform.Translate(new Vector3(0, 0, 9));
            clone.transform.SetParent(null);
            
        }
        if (ack)
        {
            if (Mathf.Abs(Lhand.rotation.eulerAngles.y - Yref) > 60)
            {
                ack = false;
                Destroy(clone);
            }
            if (ack && Lhand.rotation.eulerAngles.x>280 && Lhand.position.y>Yheight+0.2)
            {
                
                clone.GetComponent<Rigidbody>().AddForce(-clone.transform.forward * 200, ForceMode.Impulse);
                if (!sEffect.isPlaying)
                {
                    sEffect.Play();
                }
                Destroy(clone, 2f);
                ack = false;
            }
        }
    }
    private void RhandPush()
    {
        if ((Rhand.rotation.eulerAngles.z > 130 && Rhand.rotation.eulerAngles.x < 170) && ack == false && Rhand.rotation.eulerAngles.z > 130)
        {
            Yref = Rhand.rotation.eulerAngles.y;
            Yheight = Rhand.position.y;
            ack = true;
            clone = Instantiate(helper, Rhand);
            clone.transform.Translate(new Vector3(0, 2.5f, 0));
            clone.transform.Translate(new Vector3(0, 0, 9));
            clone.transform.SetParent(null);

        }
        if (ack)
        {
            print(Mathf.Abs(Rhand.rotation.eulerAngles.y - Yref));
            if (Mathf.Abs(Rhand.rotation.eulerAngles.y - Yref) > 60)
            {
                ack = false;
                Destroy(clone);
            }
            if (ack && Rhand.rotation.eulerAngles.x > 280 && Rhand.position.y > Yheight + 0.2)
            {
                
                clone.GetComponent<Rigidbody>().AddForce(-clone.transform.forward * 200, ForceMode.Impulse);
                if (!sEffect.isPlaying)
                {
                    sEffect.Play();
                }
                Destroy(clone, 2f);
                ack = false;
            }
        }
    }
    private void OnDisable()
    {
        Destroy(clone);
        ack = false;
    }
}
