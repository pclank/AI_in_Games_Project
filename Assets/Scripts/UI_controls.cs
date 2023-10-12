using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_controls : MonoBehaviour
{
    public GameObject uiObject;
    public float displayDuration = 10f;
    private bool displayMessage = false;


    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            uiObject.SetActive(false);
        }
    }

    private IEnumerator HideImageAfterDelay()
    {
    yield return new WaitForSeconds(displayDuration);
    displayMessage = false;

    if (uiObject != null)
        {
            uiObject.gameObject.SetActive(false);
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}
