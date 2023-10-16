using UnityEngine;

public class Axe : MonoBehaviour
{
    public PlayerInteraction playerInteraction;

    private bool isPickedUp = false;

    private void OnMouseDown()
    {
        if (!isPickedUp)
        {
            playerInteraction.InteractWithAxe();
            isPickedUp = true;
            gameObject.SetActive(false); // Hide the axe.
        }
    }
}
