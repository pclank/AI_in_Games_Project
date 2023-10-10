using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_controller : MonoBehaviour
{
    public GameObject portalObject;   // Reference to the portal prefab instance.
    public GameObject portalDoorObject; // Reference to the object with the "Portal" tag

    private string debugClassName = typeof(Button_controller).Name;

    private void OnMouseUpAsButton()
    {
        Debug.Log($"{debugClassName}: Button Works");
        TogglePortalVisibility();
    }

    private void TogglePortalVisibility()
    {
        if (portalObject != null)
        {
            Debug.Log($"{debugClassName}: Button toggled portal using portalObject");

            // Oh right, Portal Doors are objects, not components.
            //Component door = portalObject.GetComponent("Portal Door");
            GameObject door = portalObject.transform.Find("Portal Door").gameObject;

            if (door != null)
            {
                Debug.Log($"{debugClassName}: door is something.");

                door.SetActive(!door.activeSelf);
                //door.GetComponent<Portal_controller>().activated = !door.GetComponent<Portal_controller>().activated;

                Portal_controller doorScript = door.GetComponent<Portal_controller>();

                if (doorScript != null)
                {
                    doorScript.TogglePortalObjectVisibility();
                }
                else
                    Debug.Log($"{debugClassName}: doorScript is NULL!");
            }
            else
                Debug.Log($"{debugClassName}: door is NULL!");
        }
        else
            Debug.Log($"{debugClassName}: portalObject is NULL!");

        if (portalDoorObject != null)
        {
            Debug.Log($"{debugClassName}: Button toggled portal using portalDoorObject");

            portalDoorObject.SetActive(!portalDoorObject.activeSelf);
        }
        else
            Debug.Log($"{debugClassName}: portalDoorObject is NULL!");
    }
}
