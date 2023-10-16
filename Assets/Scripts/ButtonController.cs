using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject instructionsCanvas;
    private float displayTime = 15.0f;
    private bool isButtonPressed = false;

    private void Update()
    {
        if (isButtonPressed)
        {
            if (Time.time >= displayTime)
            {
                isButtonPressed = false;
                instructionsCanvas.SetActive(false);
            }
        }
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Button Works");

        if (instructionsCanvas != null)
        {
            instructionsCanvas.SetActive(true);
            StartCoroutine(HideImageAfterDelay());
        }
    }

    private IEnumerator HideImageAfterDelay()
    {
        yield return new WaitForSeconds(displayTime);
        //displayMessage = false;

        if (instructionsCanvas != null)
        {
            instructionsCanvas.SetActive(false);
        }
    }
}