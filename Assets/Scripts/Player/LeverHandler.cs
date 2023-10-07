using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverHandler : MonoBehaviour
{
    private bool ray_hit = false;

    public void setRaycast(bool flag)
    {
        ray_hit = flag;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        //if (ray_hit && Input.GetMouseButtonUp(0))
            // TODO: Do something!
    }
}
