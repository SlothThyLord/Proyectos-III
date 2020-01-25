using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public Transform Rhand;
    public GameObject wall;
    private GameObject clone;
    private bool exists;
    private bool used;
    public AudioSource effect;
    public Transform Lhand;

    private Transform reference;

    void Start()
    {
        exists = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<ForceControl>().isLeftHandActive())
        {
            this.lHandActive();
        }
        if (this.gameObject.GetComponent<ForceControl>().isRightHandActive())
        {
            this.rHandActive();
        }
        
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }
    private void rHandActive()
    {
        if (Rhand.rotation.eulerAngles.z < 10 || Rhand.rotation.eulerAngles.z > 320 && Rhand.rotation.eulerAngles.z > 300)
        {

            if (!exists)
            {
                clone = Instantiate(wall, Rhand);
                clone.transform.Translate(new Vector3(0, 0, 1));
                exists = true;
                reference = Rhand;
            }
            if ((Rhand.rotation.eulerAngles.x + reference.rotation.eulerAngles.x >= 60 || Rhand.rotation.eulerAngles.x - reference.rotation.eulerAngles.x < 360 - 60) && Mathf.Abs(reference.eulerAngles.y-Rhand.eulerAngles.y)<30)
            {
                Vector3 target = -(Rhand.transform.position - clone.transform.position);
                clone.transform.SetParent(null);
                clone.GetComponent<Rigidbody>().AddForce(target * 100, ForceMode.Impulse);
                AudioSource f = effect;
                f.Play();
                used = true;
                if (clone != null)
                {
                    Destroy(clone, 1f);
                }
                wait();
                exists = false;
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
        }
    }
    private void lHandActive()
    {
        if (Lhand.rotation.eulerAngles.z < 10 || Lhand.rotation.eulerAngles.z > 320 && Lhand.rotation.eulerAngles.z > 300)
        {

            if (!exists)
            {
                clone = Instantiate(wall, Lhand);
                clone.transform.Translate(new Vector3(0, 0, 1)); 
                exists = true;
                reference = Lhand;
            }
            if ((Lhand.rotation.eulerAngles.x + reference.rotation.eulerAngles.x >= 60 || Lhand.rotation.eulerAngles.x - reference.rotation.eulerAngles.x < 360 - 60) && Mathf.Abs(reference.eulerAngles.y - Lhand.eulerAngles.y) < 30)
            {
                Vector3 target = -(Lhand.transform.position - clone.transform.position);
                clone.transform.SetParent(null);
                clone.GetComponent<Rigidbody>().AddForce(target * 100, ForceMode.Impulse);
                AudioSource f = effect;
                used = true;
                f.Play();
                if (clone != null)
                {
                    Destroy(clone, 1f);
                }
                wait();
                exists = false;
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
        }
    }
    public bool isUsed()
    {
        return this.used;
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
