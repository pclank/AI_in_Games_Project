using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton_controller : MonoBehaviour
{
    public GameObject crate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        string method = "OnTriggerStay";

        //Debug.Log(method);

        if (other.CompareTag("Player"))
        {
            //Debug.Log($"{method}The object was a player");

            if (Input.GetMouseButtonDown(0) && !crate.gameObject.GetComponent<Crate_breaking>().broken)
            {
                Debug.Log($"{method}The Mouse 0 button was pressed");

                gameObject.GetComponent<AudioSource>().Play();

                crate.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
    
    // Doesn't work if the object is 'asleep'/inactive?
    private void OnCollisionStay(Collision collision)
    {
        string method = "OnCollisionStay";

        //Debug.Log(method);

        if (collision.collider.CompareTag("Player"))
        {
            //Debug.Log($"{method}The object was a player");

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log($"{method}The Mouse 0 button was pressed");

                gameObject.GetComponent<AudioSource>().Play();

                crate.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}