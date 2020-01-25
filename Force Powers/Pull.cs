using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pull : MonoBehaviour
{
    public Transform Rhand;
    public Transform Lhand;
    public GameObject wall;
    private GameObject clone;
    private Vector3 rotation;
    private float arc;
    private bool exists;
    private float refPos;
    private bool used;
    public AudioSource effect;
    void Start()
    {
        exists = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<ForceControl>().isLeftHandActive())
        {
            lHandActive();
        }
        if (this.gameObject.GetComponent<ForceControl>().isRightHandActive())
        {
            rHandActive();
        }
    }

    private void lHandActive()
    {
        if (Lhand.rotation.eulerAngles.z > 145 && Lhand.rotation.eulerAngles.z < 300)
        {
            if (!exists)
            {

                clone = Instantiate<GameObject>(wall, Lhand.transform);
                clone.transform.Translate(0, 1, 12);
                clone.transform.SetParent(null);
                exists = true;
                refPos = Lhand.position.y;
            }
            if (Lhand.rotation.eulerAngles.x > 180)
            {
                arc = 360 - Lhand.rotation.eulerAngles.x;
            }
            if (rotation.x < 180f && arc > 45f && exists || Lhand.position.y>refPos+0.2)
            {
                Vector3 target = Lhand.transform.position - clone.transform.position;
                clone.GetComponent<Rigidbody>().AddForce(target * 2, ForceMode.Impulse);
                AudioSource ef = effect;
                ef.Play();
                used = true;
                if (clone != null)
                {
                    Destroy(clone, 1f);
                }
            }
        }
        else
        {
            if (clone != null)
            {
                Destroy(clone);
            }
            exists = false;
            used = false;
            rotation = Lhand.rotation.eulerAngles;
            arc = 0;
        }
    }
    private void rHandActive()
    {
        if (Rhand.rotation.eulerAngles.z > 145 && Rhand.rotation.eulerAngles.z < 300)
        {
            if (!exists)
            {

                clone = Instantiate<GameObject>(wall, Rhand.transform);
                clone.transform.Translate(0, 1, 12);
                clone.transform.SetParent(null);
                exists = true;
                refPos = Rhand.position.y;
            }
            if (Rhand.rotation.eulerAngles.x > 180)
            {
                arc = 360 - Rhand.rotation.eulerAngles.x;
            }
            if (rotation.x < 180f && arc > 45f && exists|| Rhand.position.y>refPos+0.2)
            {
                Vector3 target = Rhand.transform.position - clone.transform.position;
                clone.GetComponent<Rigidbody>().AddForce(target * 2, ForceMode.Impulse);
                AudioSource ef = effect;
                ef.Play();
                used = true;
                if(clone != null)
                {
                    Destroy(clone, 1f);
                }
            }
        }
        else
        {
            if (clone != null)
            {
                Destroy(clone);
            }
            used = false;
            exists = false;
            rotation = Rhand.rotation.eulerAngles;
            arc = 0;
        }
    }
    public bool isUsed()
    {
        return used;
    }
    private void OnEnable()
    {
        used = false;
    }
    private void OnDisable()
    {
        Destroy(clone);
    }
}
