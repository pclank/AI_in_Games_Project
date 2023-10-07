using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    public GameObject ui_text;
    public int excluded_layer = 8;              // Layer to Exclude from Raycasting
    public float max_distance = 10.0f;

    private GameObject player_object;
    private GameObject hit_gameobject;
    private int layer_mask;
    private bool hit_flag = false;

    // Disable GameObject Hit Variable
    public void disableHit()
    {
        if (gameObject.CompareTag("MainCamera") && hit_gameobject != null)
        {
            if (hit_gameobject.CompareTag("Button"))
            {
                ui_text.SetActive(false);

                hit_gameobject.GetComponent<ButtonHandler>().setRaycast(false);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player_object = GameObject.FindWithTag("Player");   // Get Player GameObject

        layer_mask = 1 << excluded_layer;                   // Bit Shift to Get Layer Bitmask
        layer_mask = layer_mask ^ (1 << 5);                 // Exclude UI Layer
        layer_mask = ~layer_mask;                           // Invert Bitmask

        Cursor.visible = false;                             // Disable Cursor
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        // Camera Based Raycast
        if (gameObject.CompareTag("MainCamera") && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, max_distance, layer_mask, QueryTriggerInteraction.Collide))  // Generate Ray and Trigger Colliders
        {
            // If a Different GameObject was Hit in the Next Update, Disable the Previous GameObject's Variable

            if (hit_flag && hit.transform.gameObject != hit_gameobject)
            {
                disableHit();

                hit_flag = false;
            }

            if (hit.transform.gameObject.CompareTag("Button"))
            {
                hit_flag = true;

                hit_gameobject = hit.transform.gameObject;

                hit_gameobject.GetComponent<ButtonHandler>().setRaycast(true);

                ui_text.SetActive(true);
            }
            else if (hit.transform.gameObject.CompareTag("Lever"))
            {
                hit_flag = true;

                hit_gameobject = hit.transform.gameObject;

                hit_gameobject.GetComponent<LeverHandler>().setRaycast(true);

                ui_text.SetActive(true);
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }

        else
        {
            if (hit_flag)
            {
                disableHit();
            }

            hit_flag = false;
        }
    }
}
