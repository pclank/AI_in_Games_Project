using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public KeyCode push_key;
    public LayerMask mask;
    public float ArmLength;
    public float delay = 1.0f;
    private bool pushing = false;

    private GameObject player_object;
    private float forceAmount = 25000.0f;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        player_object = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!pushing)
        {
            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.forward, out var hit, Mathf.Infinity, mask))
            {
                var obj = hit.collider.gameObject;

                //Debug.Log($"looking at {obj.name}", this);

                if ((obj.transform.position - this.transform.position).sqrMagnitude < ArmLength * ArmLength)
                {
                    //Debug.Log($"{obj.name} in reach", this);
                    if (Input.GetKeyDown(push_key))
                    {

                        Rigidbody rb = obj.GetComponent<Rigidbody>();
                        if (rb != null)
                        {
                            if (Time.time - timer < delay)
                                return;

                            timer = Time.time;

                            // Log push
                            player_object.GetComponent<MasterLog>().main_log.push_count++;

                            Debug.Log($"Pushing {obj.name}", this);
                            rb.AddForce(this.transform.forward * forceAmount);
                            pushing = true;
                        }
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyUp(push_key)) pushing = false;
        }
    }
}
