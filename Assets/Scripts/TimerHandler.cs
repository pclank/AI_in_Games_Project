using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerHandler : MonoBehaviour
{
    [Tooltip("Starting Time in seconds.")]
    public float timer_start = 10.0f;

    private float timer_current;

    // Is called when timer is up
    void TriggerEvent()
    {
        // TODO: Remove this and do something!
        timer_current = timer_start;
    }

    // Start is called before the first frame update
    void Start()
    {
        timer_current = timer_start;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer_current -= Time.deltaTime;
        if (timer_current <= 0.0f)
            TriggerEvent();

        GetComponent<TMP_Text>().text = "TIME:\n " + timer_current.ToString(".0") + " sec";
    }
}
