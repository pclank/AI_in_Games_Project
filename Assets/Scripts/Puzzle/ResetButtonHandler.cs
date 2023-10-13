using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButtonHandler : MonoBehaviour
{
    private bool ray_hit = false;

    public GameObject S1;
    private Vector3 S1_start_pos;
    public GameObject S2;
    private Vector3 S2_start_pos;
    public GameObject S3;
    private Vector3 S3_start_pos;

    public void setRaycast(bool flag)
    {
        ray_hit = flag;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(S1 != null)
            S1_start_pos = S1.transform.position;
        
        if(S2 != null)
            S2_start_pos = S2.transform.position;
        
        if(S3 != null)
            S3_start_pos = S3.transform.position;
        
    }

    void Update()
    {

        if (ray_hit && Input.GetMouseButtonUp(0)){
            if(S1 != null)
                S1.transform.position = S1_start_pos;
            if(S2 != null)
                S2.transform.position = S2_start_pos;
            if(S3 != null)
                S3.transform.position = S3_start_pos;
            ray_hit = false;
        }
        
    }
}
