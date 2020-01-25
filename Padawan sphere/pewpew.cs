using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pewpew : MonoBehaviour
{
    public GameObject blaster;
    public Transform blasterPos;
    public GameObject coso;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(pew());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator pew()
    {
        while (this.gameObject.GetComponent<Movement>().enabled==false)
        {
            int num = 1+Random.Range(0, 2);
            GameObject b = Instantiate(blaster, blasterPos.position, blaster.transform.rotation);
            Vector3 target = coso.transform.position - blasterPos.position;

            target.y += Random.Range(0f,0.5f);
            target.x += Random.Range(-0.7f, 0.7f);

            float alpha = Mathf.Acos(target.x / target.magnitude);
            float beta = Mathf.Acos(target.y / target.magnitude);
            float gamma = Mathf.Acos(target.z / target.magnitude);

            Vector3 youSpinMyHeadRightRoundRightRound = new Vector3(alpha, beta, gamma);
            youSpinMyHeadRightRoundRightRound = youSpinMyHeadRightRoundRightRound * 360 / (2 * Mathf.PI);

            b.transform.Rotate(youSpinMyHeadRightRoundRightRound);
            
            
            b.GetComponent<Rigidbody>().AddForce(target * 0.5f,ForceMode.Impulse);
            AudioSource bshot = this.gameObject.GetComponent<AudioSource>();
            bshot.Play();
            
            yield return new WaitForSeconds(num);
        }
        
    }
}
