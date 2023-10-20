using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning_message : MonoBehaviour
{
    [SerializeField] string beforeMessage;
    [SerializeField] string aftermessage;

    [SerializeField] GameObject UIMessageObject;

    bool messageChanged;

    // Start is called before the first frame update
    void Start()
    {
        UIMessageObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!messageChanged)
            if (other.CompareTag("Player"))
            {
                UIMessageObject.SetActive(true);
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIMessageObject.SetActive(false);
        }
    }

    public void ChangeMessage()
    {
        //Debug.Log($"Is {nameof(ChangeMessage)} being called?");

        var test = UIMessageObject.transform.Find("Message");

        //Debug.Log($"Has test = {test} been found?");

        test.GetComponent<TMPro.TMP_Text>().text = aftermessage;

        messageChanged = true;
    }
}
