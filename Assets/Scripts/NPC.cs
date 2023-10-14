using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Tooltip("Target dialogue id.")]
    public int dialogue_id;

    [Tooltip("Delay after conversation exit, before accepting raycasting.")]
    public float delay = 1.0f;

    private GameObject player_object;
    private bool ray_hit = false;
    private bool conversing = false;
    private bool enable_delay = false;
    private float delay_start;

    public void setRaycast(bool flag)
    {
        ray_hit = flag;
    }

    public void ExitConversation()
    {
        enable_delay = true;
        delay_start = Time.time;
    }    

    // Start is called before the first frame update
    void Start()
    {
        player_object = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (enable_delay && Time.time - delay_start >= delay)
        {
            conversing = false;
            enable_delay = false;
        }

        if (!conversing && ray_hit && Input.GetKeyUp(KeyCode.E))
        {
            player_object.GetComponent<Conversation>().StartDialogue(dialogue_id, gameObject);
            conversing = true;
        }
    }
}
