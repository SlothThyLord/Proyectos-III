using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dindunothin : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        bullet.AddComponent<Rigidbody>();
        bullet.AddComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.watchWereUWalkin();
        }
    }
    void watchWereUWalkin()
    {
        GameObject coso = Instantiate(bullet, pos.position, pos.rotation);
        coso.transform.localScale.Scale(new Vector3(15, 15, 15));
        coso.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * 100, ForceMode.Impulse);
        Destroy(coso, 5);
    }
}
