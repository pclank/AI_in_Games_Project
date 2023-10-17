using UnityEngine;

public class InstructionsController : MonoBehaviour
{
    public GameObject instructionsCanvas;
    private float displayTime = 15.0f; // Time to display
    private float timer;

    private void Start()
    {
        instructionsCanvas.SetActive(false);
    }

    private void Update()
    {
        if (timer < displayTime) 
        {
            instructionsCanvas.SetActive(true);
            timer += Time.deltaTime;
        }
        else
        {
            instructionsCanvas.SetActive(false);
        }
    }
}