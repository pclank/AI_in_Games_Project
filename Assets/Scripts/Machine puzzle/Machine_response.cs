using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_response : MonoBehaviour
{
    int partsInstalled;
    bool puzzleCompleted;

    AudioSource machineAudio;
    Transform messageObject;

    [SerializeField] int correctPartsNeeded;

    [Header("Objects")]
    [SerializeField] GameObject maintenanceSign;
    [SerializeField] GameObject jammedRod;
    [SerializeField] GameObject portal;

    [Header("Sound effects")]
    [SerializeField] AudioClip repairSound;
    [SerializeField] AudioClip fixedSound;
    [SerializeField] AudioClip brokenSound;

    // Start is called before the first frame update
    void Start()
    {
        machineAudio = gameObject.GetComponent<AudioSource>();

        ChangeSignText(0);

        messageObject = maintenanceSign.transform.Find("Message");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // If the portal is already active (by using the backup generator for example), we ignore any further attempts to fix/jam it?
        if (!portal.GetComponent<Portal_controller>().portalActive)
        {
            if (other.CompareTag("Correct part") && !puzzleCompleted)
            {
                //Debug.Log($"The machine was given a correct part = {other.name}.");

                partsInstalled++;
                ChangeSignText(0);

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
                    ChangeSignText(1);

                    GameObject.Find("Portal").GetComponent<Portal_controller>().TogglePortalObjectVisibility();

                    puzzleCompleted = true;
                }
            }

            else if (other.CompareTag("Incorrect part") && !puzzleCompleted)
            {
                // Remove the part from the world, as if it got installed.
                Destroy(other.gameObject);

                ChangeSignText(2);

                // Play sound effect of broken machine here.
                machineAudio.clip = brokenSound;
                machineAudio.Play();

                // The machine was solved incorrectly.
                //Debug.Log("The machine was jammed, but somehow the portal turned on.");

                GameObject.Find("Portal").GetComponent<Portal_controller>().TogglePortalObjectVisibility();

                puzzleCompleted = true;

                // ======================

                GameObject boxCollChild = jammedRod.transform.Find("KnifeSharp_low").gameObject;
                MeshRenderer[] meshRendChildren = boxCollChild.GetComponentsInChildren<MeshRenderer>();

                //Debug.Log($"{nameof(boxCollChild)} = {boxCollChild}");
                //Debug.Log($"{nameof(meshRendChildren)} = {meshRendChildren} = {meshRendChildren.Length} elements");

                // Activate box collider so player can't walk through it.
                boxCollChild.GetComponent<BoxCollider>().enabled = true;

                // Activate the mesh renderers of all meshes that make up the whole rod.
                foreach (MeshRenderer meshRend in meshRendChildren)
                {
                    meshRend.enabled = true;
                }
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

    void ChangeSignText(int type)
    {
        // Correct part
        if (type == 0 || type == 1)
        {
            //Debug.Log($"ChangeSignText --> {maintenanceSign.name}, has {maintenanceSign.GetComponentsInChildren<MeshRenderer>().Length} mesh renderers/children");

            //Transform textObject = maintenanceSign.transform.Find("Message");
            //Debug.Log($"{nameof(textObject)} --> {textObject.name}");

            TMPro.TMP_Text tmpTextObject = maintenanceSign.transform.Find("Message").GetComponent<TMPro.TMP_Text>();

            //TMPro.TMP_Text tmpTextObject = textObject.GetComponent<TMPro.TMP_Text>();

            //Debug.Log($"{nameof(tmpTextObject)} --> {tmpTextObject.name}");

            tmpTextObject.text = $"Gears replaced\n {partsInstalled} / {correctPartsNeeded}";

            // Machine fixed
            if (type == 1)
            {
                messageObject.GetComponent<TMPro.TMP_Text>().color = Color.green;
            }
        }
        // Machine broken
        else
        {
            messageObject.GetComponent<TMPro.TMP_Text>().text = "ERROR";
            messageObject.GetComponent<TMPro.TMP_Text>().color = Color.red;
        }
    }
}