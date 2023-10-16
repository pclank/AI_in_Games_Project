using UnityEngine;

public class Key : MonoBehaviour
{
    public PlayerInteraction playerInteraction;

    private bool isPickedUp = false;

    private void OnMouseDown()
    {
        if (!isPickedUp)
        {
            playerInteraction.InteractWithKey();
            isPickedUp = true;
            gameObject.SetActive(false); // Hide the key.
        }
    }
}
