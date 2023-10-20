using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton_controller : MonoBehaviour
{
    public GameObject crate;

    bool nearButton, buttonPressed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && nearButton && !buttonPressed)
        {
            //Debug.Log($"Parent = {gameObject.transform.parent.name}");
            //Debug.Log($"Mesh = {gameObject.transform.parent.Find("Mesh").name}");

            // Scaling the Button object like this also moves it for some reason?
            //gameObject.transform.parent.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            gameObject.transform.parent.Find("Mesh").localScale -= new Vector3(0.2f, 0.2f, 0.2f);
            gameObject.GetComponent<AudioSource>().Play();

            crate.gameObject.GetComponent<Rigidbody>().useGravity = true;

            buttonPressed = true;

            // =================
            gameObject.transform.parent.Find("Warning trigger").GetComponent<Warning_message>().ChangeMessage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //string method = "OnTriggerEnter";
        //Debug.Log(method);

        if (other.CompareTag("Player"))
        {
            nearButton = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        nearButton = false;
    }
}