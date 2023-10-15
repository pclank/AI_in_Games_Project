using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_response : MonoBehaviour
{
    public int correctPartsNeeded;
    int partsInstalled;
    bool puzzleCompleted;

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
        if (other.CompareTag("Correct part") && !puzzleCompleted)
        {
            partsInstalled++;

            // Play sound effect of part getting installed here.

            // Remove the part from the world, as if it got installed.
            Destroy(other);

            // The machine was solved correctly.
            if (partsInstalled == correctPartsNeeded)
            {
                // Play sound effect of machine getting fixed here.

                Debug.Log("The machine got enough parts now.");

                GameObject.Find("Portal").GetComponent<Portal_controller>().TogglePortalObjectVisibility();

                puzzleCompleted = true;
            }
        } 
        
        else if (other.CompareTag("Incorrect part") && !puzzleCompleted)
        {
            // Remove the part from the world, as if it got installed.
            Destroy(other);

            // Play sound effect of broken machine here.

            // The machine was solved incorrectly.
            Debug.Log("The machine was jammed, but somehow the portal turned on.");

            GameObject.Find("Portal").GetComponent<Portal_controller>().TogglePortalObjectVisibility();

            puzzleCompleted = true;
        }
        else
            Debug.Log("The machine was given something that shouldn't be interacting with it.");
    }
}
