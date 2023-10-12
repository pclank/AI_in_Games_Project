using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_controller : MonoBehaviour
{
    private GameObject portalDoor;

    public bool initialActiveValue; // Whether the portal is already activated.
    public string sceneToLoad = "OutdoorsScene"; // The name of the scene to load

    private string debugClassName = typeof(Portal_controller).Name;

    void Start()
    {
        portalDoor = GameObject.Find("Portal Door");

        Debug.Log($"{debugClassName}: Toggle portal");

        if (initialActiveValue)
        {
            Debug.Log($"{debugClassName}: Initialize active portal");
        }
        else
        {
            portalDoor.SetActive(!portalDoor.activeSelf);

            Debug.Log($"{debugClassName}: Initialize inactive portal");
        }
    }

    public void TogglePortalObjectVisibility()
    {
        if (portalDoor != null)
        {
            portalDoor.SetActive(!portalDoor.activeSelf);
        }
        else
            Debug.Log($"{debugClassName}: portalDoor is NULL!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"{debugClassName}: Player collided with portal.");

            // Only teleport if the portal is active.
            if (portalDoor.activeSelf)
                LoadScene();
        }
    }

    private void LoadScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
