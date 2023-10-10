using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_controller : MonoBehaviour
{
    public GameObject portalObject; // Reference to the object with the "Portal" tag

    private void OnMouseUpAsButton()
    {
        Debug.Log("Button Works");
        TogglePortalVisibility();
    }

    private void TogglePortalVisibility()
    {
        if (portalObject != null)
        {
            portalObject.SetActive(!portalObject.activeSelf);
        }
    }
}
