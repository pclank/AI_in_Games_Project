using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// ************************************************************************************
// JSON Object Class
// ************************************************************************************
[System.Serializable]
public class JFloatingDialogue
{
    public int dialogue_id;
    public string dialogue_name;
    public int n_lines;
    public JFloatingLines[] lines;
}

[System.Serializable]
public class JFloatingLines
{
    public int line_id;
    public string line;
}


// ************************************************************************************
// JSON Object List Class
// ************************************************************************************
[System.Serializable]
public class JFloatingDialogue_list
{
    public JFloatingDialogue[] dialogue_list;
}

public class FloatingText : MonoBehaviour
{
    [Tooltip("The JSON file.")]
    public TextAsset json_file_name;

    [Tooltip("The ID of the dialogue.")]
    public int d_id;

    [Tooltip("Start at Runtime start.")]
    public bool start_at_runtime = true;

    public float delay = 2.0f;

    [Tooltip("Rotation speed towards player.")]
    public float rotation_speed = 2.0f;

    private JFloatingDialogue[] dialogue_in_json;
    private JFloatingDialogue target_dialogue;
    private GameObject player_object;
    private int current_line_id = 0;
    private float timer;
    private bool dialogue_on = false;
    
    /// <summary>
    /// Start Floating Dialogue
    /// </summary>
    public void StartDialogue()
    {
        dialogue_on = true;
        timer = Time.time;
        gameObject.GetComponent<TMP_Text>().text = target_dialogue.lines[0].line;
        gameObject.GetComponent<TMP_Text>().enabled = true;

        current_line_id++;
        if (current_line_id >= target_dialogue.n_lines)
            current_line_id = 0;
    }

    /// <summary>
    /// Stop Floating Dialogue
    /// </summary>
    public void StopDialogue()
    {
        dialogue_on = false;
        gameObject.GetComponent<TMP_Text>().enabled = false;
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction_vec = -(player_object.transform.position - transform.position).normalized;

        Quaternion rotation_quat = Quaternion.LookRotation(direction_vec);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation_quat, Time.deltaTime * rotation_speed);
    }

    // Start is called before the first frame update
    void Start()
    {
        player_object = GameObject.FindWithTag("Player");
        dialogue_in_json = JsonUtility.FromJson<JFloatingDialogue_list>(json_file_name.text).dialogue_list;
        target_dialogue = dialogue_in_json[d_id];

        if (start_at_runtime)
            StartDialogue();
    }

    void Update()
    {
        if (!dialogue_on)
            return;

        RotateTowardsPlayer();

        if (Time.time - timer >= delay)
        {
            gameObject.GetComponent<TMP_Text>().text = target_dialogue.lines[current_line_id].line;

            current_line_id++;
            if (current_line_id >= target_dialogue.n_lines)
                current_line_id = 0;

            timer = Time.time;
        }
    }
}
