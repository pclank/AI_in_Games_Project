using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject teleport_location_object;
    public GameObject teleport_effect_ui;
    public Vector3 teleport_translation = new Vector3(0.1f, 0.0f, 0.0f);
    public Vector3 teleport_rotation = new Vector3(0.0f, 180.0f, 0.0f);
    public float increment_value = 0.01f;

    private GameObject player_object;
    private GameObject camera_object;
    private float timer_start;
    private bool t_enabled;
    private bool teleported;

    public void Teleport()
    {
        // Freeze player
        player_object.GetComponent<FirstPersonMovement>().stop_flag = true;
        camera_object.GetComponent<FirstPersonLook>().stop_flag = true;

        teleported = false;
        t_enabled = true;
        teleport_effect_ui.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        t_enabled = false;
        player_object = GameObject.FindWithTag("Player");
        camera_object = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!t_enabled)
            return;

        // Enable FX before teleport
        if (!teleported && teleport_effect_ui.GetComponent<Image>().color.a <= 1.0f)
        {
            float new_alpha = teleport_effect_ui.GetComponent<Image>().color.a + increment_value;

            // Teleport
            if (new_alpha >= 1.0f)
            {
                new_alpha = 1.0f;
                teleported = true;

                player_object.GetComponent<Transform>().position = teleport_location_object.GetComponent<Transform>().position + teleport_translation;
                //player_object.transform.Rotate(teleport_rotation);
            }

            teleport_effect_ui.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, new_alpha);
        }
        // FX after teleport
        else if (teleported && teleport_effect_ui.GetComponent<Image>().color.a >= 0.0f)
        {
            float new_alpha = teleport_effect_ui.GetComponent<Image>().color.a - increment_value;

            if (new_alpha <= 0.0f)
            {
                new_alpha = 0.0f;
                teleported = false;
                t_enabled = false;
                teleport_effect_ui.SetActive(false);

                // Unfreeze player
                player_object.GetComponent<FirstPersonMovement>().stop_flag = false;
                camera_object.GetComponent<FirstPersonLook>().stop_flag = false;
            }

            teleport_effect_ui.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, new_alpha);
        }
    }
}
