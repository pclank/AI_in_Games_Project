using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_response : MonoBehaviour
{
    public int correctPartsNeeded;
    int partsInstalled;
    bool puzzleCompleted;

    AudioSource machineAudio;

    [Header("Sound effects")]
    [SerializeField] AudioClip repairSound;
    [SerializeField] AudioClip fixedSound;
    [SerializeField] AudioClip brokenSound;

    // Start is called before the first frame update
    void Start()
    {
        machineAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Correct part") && !puzzleCompleted)
        {
            //Debug.Log($"The machine was given a correct part = {other.name}.");

            partsInstalled++;

            // Play sound effect of part getting installed here.
            machineAudio.clip = repairSound;
            machineAudio.Play();

            // Remove the part from the world, as if it got installed.
            Destroy(other.gameObject);

            // The machine was solved correctly.
            if (partsInstalled == correctPartsNeeded)
            {
                // Play sound effect of machine getting fixed here.
                machineAudio.clip = fixedSound;
                machineAudio.loop = true;
                machineAudio.Play();

                //Debug.Log("The machine got enough parts now.");

                GameObject.Find("Portal").GetComponent<Portal_controller>().TogglePortalObjectVisibility();

                puzzleCompleted = true;
            }
        }

        else if (other.CompareTag("Incorrect part") && !puzzleCompleted)
        {
            // Remove the part from the world, as if it got installed.
            Destroy(other.gameObject);

            // Play sound effect of broken machine here.
            machineAudio.clip = brokenSound;
            machineAudio.Play();

            // The machine was solved incorrectly.
            Debug.Log("The machine was jammed, but somehow the portal turned on.");

            GameObject.Find("Portal").GetComponent<Portal_controller>().TogglePortalObjectVisibility();

            puzzleCompleted = true;
        }
        else if (other.CompareTag("Player"))
        {
            // Don't print any debug logs if the player gets really close.
        }
        else
        {
            //Debug.Log($"The machine was given something ({other.name}) that shouldn't be interacting with it.");
        }
    }
}
