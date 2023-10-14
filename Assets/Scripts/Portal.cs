using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject location_object;

    public Vector3 offset = new Vector3(0.0f, 1.0f, 0.0f);

    public bool needs_item = true;
    public int item_id = -1;

    private GameObject player_object;
    private bool ray_hit;
    private bool portal_enabled = false;


    public void setRaycast(bool flag)
    {
        ray_hit = flag;
    }

    public void EnablePortal()
    {
        portal_enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        player_object = GameObject.FindWithTag("Player");

        if (needs_item)
            portal_enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!portal_enabled)
            return;

        if (ray_hit && Input.GetKeyUp(KeyCode.F))
        {
            if (needs_item && !player_object.GetComponent<Inventory>().CheckForItem(item_id))
                return;

            player_object.transform.position = location_object.transform.position + offset;

            portal_enabled = false;
            //Destroy(gameObject);
        }
    }
}
