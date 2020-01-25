using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smash : MonoBehaviour
{
    public Transform Rhand;
    public Transform Lhand;
    public Transform player;
    public GameObject wall;
    public AudioSource effect;

    private Transform reference;
    private GameObject andHisNameIsJohnCena;
    private float refr;
    void Start()
    {
        reference = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<ForceControl>().isLeftHandActive())
        {
            this.Lsmash();
        }
        if (this.GetComponent<ForceControl>().isRightHandActive())
        {
            this.Rsmash();
        }
    }
    private void Lsmash()
    {
        if ((Lhand.rotation.eulerAngles.x < 10 || Lhand.rotation.eulerAngles.x > 320) && reference == null)
        {
            reference = Lhand.transform;
            refr = Lhand.rotation.eulerAngles.y;
            print("reference acquired:" + reference);
        }

        if (reference != null && (Lhand.rotation.eulerAngles.x > 320 || Lhand.rotation.eulerAngles.x < 10))
        {
            print(Mathf.Abs(refr - Lhand.rotation.eulerAngles.y));
            if (Mathf.Abs(refr - Lhand.rotation.eulerAngles.y) > 40)
            {
                Vector3 position = player.position;
                position.y += 3;
                Vector3 hulkSMASH = new Vector3(0, 100, 0);
                andHisNameIsJohnCena = Instantiate(wall, position, wall.transform.rotation);
                andHisNameIsJohnCena.GetComponent<Rigidbody>().AddForce(hulkSMASH, ForceMode.Impulse);
                Destroy(andHisNameIsJohnCena, 2f);
                reference = null;
            }
        }
        if ((Lhand.rotation.eulerAngles.x > 10 && Lhand.rotation.eulerAngles.x < 40) || (Lhand.rotation.eulerAngles.x < 320 && Lhand.rotation.eulerAngles.x > 300))
        {
            reference = null;
            print("NULL");
        }
    }
    private void Rsmash()
    {
        if ((Rhand.rotation.eulerAngles.x < 10 || Rhand.rotation.eulerAngles.x > 320) && reference == null)
        {
            reference = Rhand.transform;
            refr = Rhand.rotation.eulerAngles.y;
            print("reference acquired:" + reference);
        }

        if (reference != null && (Rhand.rotation.eulerAngles.x > 320 || Rhand.rotation.eulerAngles.x < 10))
        {
            print("skidaddle skidoodle, your face is now a noodle"+Mathf.Abs(refr - Rhand.rotation.eulerAngles.y));
            if (Mathf.Abs(refr - Rhand.rotation.eulerAngles.y) > 40)
            {
                Vector3 position = player.position;
                position.y += 3;
                Vector3 hulkSMASH = new Vector3(0, 100, 0);
                andHisNameIsJohnCena = Instantiate(wall, position, wall.transform.rotation);
                andHisNameIsJohnCena.GetComponent<Rigidbody>().AddForce(hulkSMASH, ForceMode.Impulse);
                Destroy(andHisNameIsJohnCena, 2f);
                reference = null;
            }
        }
        if ((Rhand.rotation.eulerAngles.x > 10 && Rhand.rotation.eulerAngles.x < 40) || (Rhand.rotation.eulerAngles.x < 320 && Rhand.rotation.eulerAngles.x > 300))
        {
            reference = null;
            print("NULL");
        }
    }
}
