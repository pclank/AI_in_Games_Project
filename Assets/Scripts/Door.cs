using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked = false;

    public Animator doorAnimator; // Attach a door animation controller.

    private bool isAnimating = false;

    private void Update()
    {
        if (isAnimating && !doorAnimator.GetCurrentAnimatorStateInfo(0).IsName("DoorOpeningAnimation"))
        {
            isAnimating = false;
            Open();
        }
    }

    public void Open()
    {
        if (!isLocked)
        {
            // You can play the door opening animation here.
            if (doorAnimator != null)
            {
                doorAnimator.SetBool("Opened", true);
                isAnimating = true;
            }
            else
            {
                Debug.Log("The door opened.");
                // Implement door opening logic without animation.
            }
        }
        else
        {
            Debug.Log("The door is locked. You need a key or an axe to open it.");
        }
    }
}
