using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_controls : MonoBehaviour
{
    public GameObject uiObject;
    public float displayDuration = 5f;

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
            StartCoroutine(HideImageAfterDelay());
        }
    }

    private IEnumerator HideImageAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);

        if (uiObject != null)
        {
            uiObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Your update logic here, if needed
    }
}
