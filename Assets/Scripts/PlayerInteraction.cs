using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Door door;
    public Axe axe;
    public Key key;
    public Animator Animator; // Attach the door Animator controller.
    public GameObject smashHint;
    public GameObject openHint;
    public GameObject bothHint;

    private bool hasAxe = false;
    private bool hasKey = false;

    private void Start()
    {
        smashHint.SetActive(false);
        openHint.SetActive(false);
        bothHint.SetActive(false);
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
        Animator.SetTrigger("Smashed");
        // Play sound effect.
    }

    private void OpenDoor()
    {
        door.gameObject.SetActive(false); // Hide the door.
        Animator.SetTrigger("Opened");
    }

    public void InteractWithAxe()
    {
        hasAxe = true;
        Debug.Log("You picked up the axe.");
    }

    public void InteractWithKey()
    {
        hasKey = true;
        Debug.Log("You found the key.");
    }
}
