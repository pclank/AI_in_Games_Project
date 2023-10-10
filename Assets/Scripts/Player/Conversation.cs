using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ************************************************************************************
// JSON Object Class
// ************************************************************************************
[System.Serializable]
public class JDialogue
{
    public int dialogue_id;
    public string dialogue_name;
    public JNPCDialogue[] npc_lines;
    public JPlayerDialogue[] player_lines;
}

[System.Serializable]
public class JNPCDialogue
{
    public int line_id;
    public int player_id;
    public string line;
}

[System.Serializable]
public class JPlayerDialogue
{
    public int line_id;
    public JPlayerChoice[] choices;
}

[System.Serializable]
public class JPlayerChoice
{
    public int next_npc_line;
    public string response_type;
    public string line;
}


// ************************************************************************************
// JSON Object List Class
// ************************************************************************************
[System.Serializable]
public class Jdialogue_list
{
    public JDialogue[] dialogue_list;
}


public class Conversation : MonoBehaviour
{
    [Tooltip("JSON file containing the dialogue.")]
    public TextAsset json_file_name;                    // JSON File with Item Information

    public GameObject dialogue_ui;
    public GameObject npc_ui;
    public GameObject choice0_ui;
    public GameObject choice1_ui;
    public GameObject choice2_ui;

    private string json_string;
    private JDialogue[] dialogue_in_json;
    private GameObject player_object;
    private GameObject camera_object;
    private GameObject npc_object;
    private bool is_running = false;                    // Whether the player is conversing (prevents raycasting stuff)
    private int dialogue_id;
    private int dialogue_state = 0;

    private JDialogue current_dialogue;

    public bool isRunning()
    {
        return is_running;
    }    

    public void StartDialogue(int d_id, GameObject npc)
    {
        npc_object = npc;

        camera_object.GetComponent<RayCasting>().raycast_enabled = false;

        dialogue_id = d_id;

        // Freeze player
        player_object.GetComponent<FirstPersonMovement>().stop_flag = true;
        camera_object.GetComponent<FirstPersonLook>().stop_flag = true;

        Cursor.lockState = CursorLockMode.None;         // Unlock Cursor
        Cursor.visible = true;                          // Make Cursor Visible

        int player_line_id = dialogue_in_json[dialogue_id].npc_lines[dialogue_state].player_id;

        DisplayDialogue();

        dialogue_ui.SetActive(true);
    }

    public void ContinueDialogue(int choice_id)
    {
        int prev_state = dialogue_state;
        dialogue_state = dialogue_in_json[dialogue_id].player_lines[dialogue_in_json[dialogue_id].npc_lines[dialogue_state].player_id].choices[choice_id].next_npc_line;

        // Exit dialogue
        if (dialogue_state == -1)
        {
            dialogue_state = prev_state;
            EndDialogue();

            return;
        }

        DisplayDialogue();
    }

    private void EndDialogue()
    {
        npc_ui.SetActive(false);
        choice0_ui.SetActive(false);
        choice1_ui.SetActive(false);
        choice2_ui.SetActive(false);
        dialogue_ui.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;                               // Lock Cursor to Center
        Cursor.visible = false;                                                 // Hide Cursor

        // Unfreeze player
        player_object.GetComponent<FirstPersonMovement>().stop_flag = false;
        camera_object.GetComponent<FirstPersonLook>().stop_flag = false;

        camera_object.GetComponent<RayCasting>().raycast_enabled = true;

        npc_object.GetComponent<NPC>().ExitConversation();
    }

    private void DisplayDialogue()
    {
        npc_ui.GetComponent<TMP_Text>().text = dialogue_in_json[dialogue_id].npc_lines[dialogue_state].line;
        int player_line_id = dialogue_in_json[dialogue_id].npc_lines[dialogue_state].player_id;
        choice0_ui.GetComponentInChildren<TMP_Text>().text = dialogue_in_json[dialogue_id].player_lines[player_line_id].choices[0].line;
        choice1_ui.GetComponentInChildren<TMP_Text>().text = dialogue_in_json[dialogue_id].player_lines[player_line_id].choices[1].line;
        choice2_ui.GetComponentInChildren<TMP_Text>().text = dialogue_in_json[dialogue_id].player_lines[player_line_id].choices[2].line;

        npc_ui.SetActive(true);
        choice0_ui.SetActive(true);
        choice1_ui.SetActive(true);
        choice2_ui.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        player_object = GameObject.FindWithTag("Player");
        camera_object = GameObject.FindWithTag("MainCamera");
        dialogue_in_json = JsonUtility.FromJson<Jdialogue_list>(json_file_name.text).dialogue_list;
    }
}
