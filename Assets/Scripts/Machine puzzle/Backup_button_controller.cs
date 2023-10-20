using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backup_button_controller : MonoBehaviour
{
    bool nearButton, pressed;

    [SerializeField] GameObject backupGenerator;
    [SerializeField] GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && nearButton && !pressed)
        {
            Transform buttonParent = gameObject.transform.parent;

            // Scaling the Button object like this also moves it for some reason?
            //gameObject.transform.parent.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            buttonParent.localScale -= new Vector3(0.2f, 0.2f, 0.2f);


            // TODO LOG backup generator used here.

            // Play click sound
            buttonParent.GetComponent<AudioSource>().Play();

            // Having both generators make sound is a bit much, one is enough.
            if (!portal.GetComponent<Portal_controller>().portalActive)
            {
                // Play generator sound.
                backupGenerator.GetComponent<AudioSource>().Play();
            }

            portal.GetComponent<Portal_controller>().TogglePortalObjectVisibility();

            pressed = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Is this being called?");

            /*
            Transform parentEmergPowButton = gameObject.transform.parent;

            Debug.Log($"gameObject.name = {gameObject.name}");
            Debug.Log($"{nameof(parentEmergPowButton)}.name = {parentEmergPowButton.name}");

            GameObject backupGenObject = parentEmergPowButton.parent.Find("Backup generator").gameObject;

            Debug.Log($"{nameof(backupGenObject)} = {backupGenObject}");
            Debug.Log($"{nameof(backupGenObject)}.name = {backupGenObject.name}");
            */

            //backupGenObject.GetComponent<AudioSource>().Play();

            nearButton = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        nearButton = false;
    }
}
