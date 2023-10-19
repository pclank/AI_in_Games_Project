using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_UI : MonoBehaviour
{
    public GameObject player;
    public GameObject fpc;

    public GameObject UI_element;

    private FirstPersonMovement fpm;
    private FirstPersonLook fpl;
    // Start is called before the first frame update
    void Start()
    {
        fpm = player.GetComponent<FirstPersonMovement>();
        if(fpm != null) fpm.stop_flag = true; 
        fpl = fpc.GetComponent<FirstPersonLook>();
        if(fpl != null) fpl.stop_flag = true;    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(fpm != null) fpm.stop_flag = false; 
            if(fpl != null) fpl.stop_flag = false;  
            UI_element.SetActive(false);
        }
    }
}
