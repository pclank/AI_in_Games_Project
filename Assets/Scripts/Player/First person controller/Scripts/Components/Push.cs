using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public string PushKey;
    public LayerMask mask; 
    public float ArmLength; 
    private bool pushing = false;

    private float forceAmount = 25000.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!pushing){
            if(Physics.Raycast(transform.position + new Vector3(0,0.5f,0) , transform.forward, out var hit, Mathf.Infinity, mask))
            {
            var obj = hit.collider.gameObject;
        
            Debug.Log($"looking at {obj.name}", this);

            if ((obj.transform.position - this.transform.position).sqrMagnitude < ArmLength*ArmLength)
            {
                Debug.Log($"{obj.name} in reach", this);
                if(Input.GetKeyDown(PushKey)){
                 
                    Rigidbody rb = obj.GetComponent<Rigidbody>();
                    if(rb != null) { 
                        Debug.Log($"Pushing {obj.name}", this); 
                        rb.AddForce(this.transform.forward * forceAmount);
                        pushing = true;
                        }
                }
            }
            }
        } else {
            if (Input.GetKeyUp(PushKey)) pushing = false;
        }
    }
}
