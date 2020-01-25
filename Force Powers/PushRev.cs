using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRev : MonoBehaviour
{
    public Transform Lhand;
    public Transform Rhand;
    public GameObject helper;
    public AudioSource sEffect;

    private float Yref;
    private float Xref;
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
        if((Lhand.rotation.eulerAngles.x>320 || Lhand.rotation.eulerAngles.x<20) && ack == false && (Lhand.rotation.eulerAngles.z<20||Lhand.rotation.eulerAngles.z>340))
        {
            Yref = Lhand.rotation.eulerAngles.y;
            Xref = Lhand.rotation.eulerAngles.x;
            ack = true;
            clone = Instantiate(helper, Lhand);
        }
        if (ack)
        {
            if (Mathf.Abs(Lhand.rotation.eulerAngles.y - Yref) > 40)
            {
                ack = false;
                Destroy(clone);
            }
            if(ack && Mathf.Abs(Lhand.rotation.eulerAngles.x - Xref) > 40)
            {
                clone.transform.Translate(new Vector3(0, -0.5f, 0));
                clone.transform.SetParent(null);
                clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * 200, ForceMode.Impulse);
                if (!sEffect.isPlaying)
                {
                    sEffect.Play();
                }
                Destroy(clone, 1f);
                ack = false;

            }
        }
    }
    private void RhandPush()
    {
        if ((Rhand.rotation.eulerAngles.x > 320 || Rhand.rotation.eulerAngles.x < 20) && ack == false && (Rhand.rotation.eulerAngles.z < 20 || Rhand.rotation.eulerAngles.z > 340))
        {
            Yref = Rhand.rotation.eulerAngles.y;
            Xref = Rhand.rotation.eulerAngles.x;
            ack = true;
            clone = Instantiate(helper, Rhand);
            
        }
        if (ack)
        {
            if (Mathf.Abs(Rhand.rotation.eulerAngles.y - Yref) > 40)
            {
                Destroy(clone);
                ack = false;
            }
            if (ack && Mathf.Abs(Rhand.rotation.eulerAngles.x - Xref) > 40)
            {
                clone.transform.Translate(new Vector3(0, -0.5f, 0));
                clone.transform.SetParent(null);
                clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * 200, ForceMode.Impulse);
                if (!sEffect.isPlaying)
                {
                    sEffect.Play();
                }
                Destroy(clone, 1f);
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
