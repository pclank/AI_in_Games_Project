using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate_breaking : MonoBehaviour
{
    public bool broken;
    public Material brokenCrate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!broken && gameObject.GetComponent<Rigidbody>().useGravity)
        {       
            // Play glass breaking if hitting anything and only once.
            gameObject.GetComponent<AudioSource>().Play();

            broken = true;

            gameObject.GetComponent<MeshRenderer>().material = brokenCrate;

            // This removes the crate, but also to fast for the sound to play.
            //Destroy(gameObject);
        }
    }
}
