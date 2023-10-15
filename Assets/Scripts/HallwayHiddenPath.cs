using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayHiddenPath : MonoBehaviour
{
    public GameObject hidden_wall_object;
    public float timer_duration = 10.0f;

    private bool timer_on = false;
    private float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer = Time.time;
            timer_on = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer_on && Time.time - timer >= timer_duration)
        {
            hidden_wall_object.GetComponent<AudioSource>().Play();

            //hidden_wall_object.SetActive(false);
            hidden_wall_object.GetComponent<MeshRenderer>().enabled = false;
            hidden_wall_object.GetComponent<BoxCollider>().enabled = false;

            timer_on = false;
            Destroy(gameObject);
        }
    }
}
