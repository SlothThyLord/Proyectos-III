using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBlaster : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource noise;
    public AudioSource noise2;
    
    
    private AudioSource delflectionNoise;
    private AudioSource lightSaberdeflect;
    void Start()
    {
        delflectionNoise = noise;
        lightSaberdeflect = noise2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("lightsaber"))
        {
            lightSaberdeflect.Play();
        }
        else
        {
            delflectionNoise.Play();
        }
        Destroy(this.gameObject);
    }
}
