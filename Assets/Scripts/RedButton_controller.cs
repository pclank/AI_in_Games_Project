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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On Trigger Enter");

        if (other.CompareTag("Player"))
        {
            Debug.Log("It is a player that just entered");

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("The Mouse 0 button was pressed");

                crate.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("The A button was pressed");
            }
        }
    }
}