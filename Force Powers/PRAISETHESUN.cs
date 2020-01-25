using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRAISETHESUN : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform Lhand;
    public Transform Rhand;
    public Transform player;
    public GameObject wall;
    public AudioSource effect;

    private bool ascending;
    private bool used;
    private Transform reference;
    private GameObject clone;

    void Start()
    {
        ascending = false;
        used = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<ForceControl>().isLeftHandActive())
        {
            LhandLift();
        }
        if (this.GetComponent<ForceControl>().isRightHandActive())
        {
            RhandLift();
        }
    }
    public bool isAscending()
    {
        return this.ascending;
    }
    public Transform handpos()
    {
        return Lhand;
    }
    public bool isUsed()
    {
        return used;
    }
    private void OnEnable()
    {
        used = false;
    }
    private void LhandLift()
    {
        if (Lhand.position.y < 1.5 && !ascending)
        {
            if (Lhand.rotation.eulerAngles.x > 40)
            {
                ascending = true;
                reference = Lhand;
            }
        }
        if (Lhand.position.y > 1.6 && ascending)
        {

            if (Lhand.rotation.eulerAngles.x < 300 && Lhand.rotation.eulerAngles.z > 130)
            {
                ascending = false;
                if (clone == null)
                {
                    clone = Instantiate(wall, player);
                    clone.transform.Translate(new Vector3(0, -0.5f, 0));
                    clone.GetComponent<Rigidbody>().AddForce(new Vector3(0, 50, 0), ForceMode.Impulse);
                    effect.Play();
                    used = true;
                }
                Destroy(clone, 1f);
            }
        }
        if (ascending)
        {
            if (Lhand.position.y < reference.position.y - 0.2)
            {
                ascending = false;
            }
        }
    }
    private void RhandLift()
    {
        if (Rhand.position.y < 1.5 && !ascending)
        {
            if (Rhand.rotation.eulerAngles.x > 40)
            {
                ascending = true;
                reference = Rhand;
            }
        }
        if (Rhand.position.y > 2 && ascending)
        {

            if (Rhand.rotation.eulerAngles.x < 300 && Rhand.rotation.eulerAngles.z > 130)
            {
                ascending = false;
                if (clone == null)
                {
                    clone = Instantiate(wall, player);
                    clone.transform.Translate(new Vector3(0, -0.5f, 0));
                    clone.GetComponent<Rigidbody>().AddForce(new Vector3(0, 50, 0), ForceMode.Impulse);
                    effect.Play();
                    used = true;
                }
                Destroy(clone, 1f);
            }
        }
        if (ascending)
        {
            if (Rhand.position.y < reference.position.y - 0.2)
            {
                ascending = false;
            }
        }
    }
}
