using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Door door;
    public Axe axe;
    public Key key;
    public Animator Animator;
    public GameObject smashHint;
    public GameObject openHint;
    public GameObject bothHint;
    public GameObject pickedKey;
    public GameObject pickedAxe;
    public AudioSource SmashAudio;
    public AudioSource OpeningAudio;


    private bool hasAxe = false;
    private bool hasKey = false;

    private void Start()
    {
        smashHint.SetActive(false);
        openHint.SetActive(false);
        bothHint.SetActive(false);
        pickedAxe.SetActive(false);
        pickedKey.SetActive(false);
        //Animator.SetBool("Opened", false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Door") && IsInteractingWithDoor())
                {
                    if (hasAxe && hasKey)
                    {
                        bothHint.SetActive(true);
                        openHint.SetActive(false);
                        smashHint.SetActive(false);
                    }
                    else if (hasAxe)
                    {
                        smashHint.SetActive(true);
                        bothHint.SetActive(false);
                        openHint.SetActive(false);
                    }
                    else if (hasKey)
                    {
                        openHint.SetActive(true);
                        smashHint.SetActive(false);
                        bothHint.SetActive(false);
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && hasAxe)
        {
            SmashDoor();
            smashHint.SetActive(false);
            bothHint.SetActive(false);
            openHint.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.F) && hasKey)
        {
            OpenDoor();
            openHint.SetActive(false);
            bothHint.SetActive(false);
            smashHint.SetActive(false);
        }
        
    }

    private bool IsInteractingWithDoor()
    {
        return !door.isLocked;
    }

    private void SmashDoor()
    {
        door.gameObject.SetActive(false); // Hide the door.
        //Animator.SetTrigger("Smashed");
        if (SmashAudio != null)
        {
        // Play the audio clip when the door is smashed.
            SmashAudio.Play();
        }
    }

    private void OpenDoor()
    {
        door.gameObject.SetActive(false); // Hide the door.
        //Animator.SetBool("Opened", true);
        if (OpeningAudio != null)
        {
        // Play the audio clip when the door is smashed.
            OpeningAudio.Play();
        }
    }

    public void InteractWithAxe()
    {
        hasAxe = true;
        Debug.Log("You picked up the axe.");
        pickedAxe.SetActive(true);
        Invoke("DeactivateAxe", 5.0f);
    }

    public void InteractWithKey()
    {
        hasKey = true;
        Debug.Log("You found the key.");
        pickedKey.SetActive(true);
        Invoke("DeactivateKey", 5.0f);
    }

    private void DeactivateKey()
    {
        pickedKey.SetActive(false);
    }

    private void DeactivateAxe()
    {
        pickedAxe.SetActive(false);
    }
}
