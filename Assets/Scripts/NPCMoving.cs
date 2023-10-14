using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMoving : MonoBehaviour
{
    [Tooltip("Teleport target.")]
    public GameObject teleport_target;

    [Tooltip("Offset for teleport.")]
    public Vector3 offset;

    [Tooltip("Target dialogue id.")]
    public int dialogue_id;

    [Tooltip("Delay after conversation exit, before accepting raycasting.")]
    public float delay = 1.0f;

    [Tooltip("Whether to disable a floating dialogue object after conversation start.")]
    public bool disable_floating = false;

    [Tooltip("Floating Dialogue to disable after conversation start.")]
    public GameObject floating_object;

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

    public void Teleport()
    {
        gameObject.transform.position = teleport_target.transform.position + offset;
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

            if (disable_floating && floating_object != null)
                floating_object.GetComponent<FloatingText>().StopDialogue();
        }
    }
}
