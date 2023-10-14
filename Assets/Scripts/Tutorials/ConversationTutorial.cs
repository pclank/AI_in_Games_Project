using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTutorial : MonoBehaviour
{
    public GameObject ui_object;
    public GameObject sfx_object;

    private GameObject player_object;
    private GameObject camera_object;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            DisplayTutorial();
    }

    public void DisableTutorial()
    {
        ui_object.SetActive(false);

        // Unfreeze player
        player_object.GetComponent<FirstPersonMovement>().stop_flag = false;
        camera_object.GetComponent<FirstPersonLook>().stop_flag = false;

        Cursor.lockState = CursorLockMode.Locked;                               // Lock Cursor to Center
        Cursor.visible = false;                                                 // Hide Cursor

        camera_object.GetComponent<RayCasting>().raycast_enabled = true;

        Destroy(gameObject);
    }

    private void DisplayTutorial()
    {
        sfx_object.GetComponent<SFXPlayer>().PlaySFX(1);

        // Freeze player
        player_object.GetComponent<FirstPersonMovement>().stop_flag = true;
        camera_object.GetComponent<FirstPersonLook>().stop_flag = true;

        Cursor.lockState = CursorLockMode.None;         // Unlock Cursor
        Cursor.visible = true;                          // Make Cursor Visible

        ui_object.SetActive(true);
    }

    void Start()
    {
        player_object = GameObject.FindWithTag("Player");
        camera_object = GameObject.FindWithTag("MainCamera");
    }
}
