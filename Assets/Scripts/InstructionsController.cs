using UnityEngine;

public class InstructionsController : MonoBehaviour
{
    public GameObject instructionsCanvas; // Reference to your Canvas containing the instructions
    private float displayTime = 25.0f; // Time in seconds to display the instructions
    private float timer;

    private void Start()
    {
        // Ensure the instructions are initially hidden
        instructionsCanvas.SetActive(false);
    }

    private void Update()
    {
        // Check if the instructions should be displayed
        if (timer < displayTime) 
        {
            // Show the instructions
            instructionsCanvas.SetActive(true);
            timer += Time.deltaTime;
        }
        else
        {
            // Hide the instructions after the specified time
            instructionsCanvas.SetActive(false);
        }
    }
}