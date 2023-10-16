using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConversationLog
{
    public int dialogue_id;

    public string choice_type;

    public ConversationLog(int id, string choice)
    {
        this.dialogue_id = id;

        this.choice_type = choice;
    }
}

public class LogConversation : MonoBehaviour
{
    private List<ConversationLog> log_list = new List<ConversationLog>();     // List of Logging Events

    // Add Analytics to List
    public void addAnalytics(int id, string choice)
    {
        log_list.Add(new ConversationLog(id, choice));

        Debug.Log(choice + " Added to Analytics");
    }

    // Record Analytics List to JSON File
    // TODO: Run when game is finished!
    public void recordAnalytics()
    {
        string c_string = "{\"conversation_log\": [" + JsonUtility.ToJson(log_list[0]) + ", ";

        for (int i = 1; i < log_list.Count; i++)
        {
            if (i == log_list.Count - 1)
                c_string += JsonUtility.ToJson(log_list[i]) + "]}";
            else
                c_string += JsonUtility.ToJson(log_list[i]) + ", ";
        }

        File.WriteAllText("conversation_log.json", c_string);
    }

    void OnApplicationQuit()
    {
        Debug.Log("Logging Conversations...");

        recordAnalytics();

        Debug.Log("Successfully logged Conversations!");
    }
}
