using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenu : MonoBehaviour
{
    public GameObject exit_ui;
    public GameObject exit_confirm_ui;

    private GameObject player_object;
    private GameObject camera_object;

    private bool menu_on = false;

    public void ReturnToGame()
    {
        Cursor.lockState = CursorLockMode.Locked;                               // Lock Cursor to Center
        Cursor.visible = false;                                                 // Hide Cursor

        // Unfreeze player
        player_object.GetComponent<FirstPersonMovement>().stop_flag = false;
        camera_object.GetComponent<FirstPersonLook>().stop_flag = false;

        camera_object.GetComponent<RayCasting>().raycast_enabled = true;

        exit_confirm_ui.SetActive(false);
        exit_ui.SetActive(false);

        menu_on = false;
    }

    public void GoToConfirmation()
    {
        exit_confirm_ui.SetActive(true);
    }

    public void ExitGame()
    {
        player_object.GetComponent<MasterLog>().WriteLog();         // Probably not needed
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        player_object = GameObject.FindWithTag("Player");
        camera_object = GameObject.FindWithTag("MainCamera");

        exit_confirm_ui.SetActive(false);
        exit_ui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Open menu
        if (!menu_on && Input.GetKeyUp(KeyCode.Escape) && !player_object.GetComponent<FirstPersonMovement>().stop_flag)
        {
            // Freeze player
            player_object.GetComponent<FirstPersonMovement>().stop_flag = true;
            camera_object.GetComponent<FirstPersonLook>().stop_flag = true;

            Cursor.lockState = CursorLockMode.None;         // Unlock Cursor
            Cursor.visible = true;                          // Make Cursor Visible

            exit_confirm_ui.SetActive(false);
            exit_ui.SetActive(true);

            menu_on = true;
        }
        // Close menu
        else if (menu_on && Input.GetKeyUp(KeyCode.Escape) && player_object.GetComponent<FirstPersonMovement>().stop_flag)
        {
            ReturnToGame();
        }
    }
}
