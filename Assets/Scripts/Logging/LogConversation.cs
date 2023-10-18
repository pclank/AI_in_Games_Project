using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConversationLog
{
    public float conversation_time;
    public int aggressive_count;
    public int diplomatic_count;
    public int deceptive_count;

    public ConversationLog()
    {
        this.conversation_time = 0.0f;
        this.aggressive_count = 0;
        this.diplomatic_count = 0;
        this.deceptive_count = 0;
    }
}

public class LogConversation : MonoBehaviour
{
    private List<ConversationLog> log_list = new List<ConversationLog>();     // List of Logging Events

    private ConversationLog conv_log = new ConversationLog();

    // Add Choice Analytics
    public void addAnalytics(int id, string choice)
    {
        if (choice == "aggressive")
            conv_log.aggressive_count++;
        else if (choice == "diplomatic")
            conv_log.diplomatic_count++;
        else if (choice == "deceptive")
            conv_log.deceptive_count++;
        else
            Debug.LogError("Wrong choice type detected!");

        Debug.Log(choice + " Added to Analytics");
    }

    // Update Conversation Time
    public void UpdateTimeLog(float time)
    {
        conv_log.conversation_time += time;

        Debug.Log(time + " Added to Analytics");
    }

    // Record Analytics List to JSON File
    // TODO: Run when game is finished!
    public void recordAnalytics()
    {
        //log_list.Add(conv_log);

        //string c_string = "{\"conversation_log\": [" + JsonUtility.ToJson(log_list[0]) + ", ";
        string c_string = "{\"conversation_log\": {" + JsonUtility.ToJson(conv_log) + "}";

        //for (int i = 1; i < log_list.Count; i++)
        //{
        //    if (i == log_list.Count - 1)
        //        c_string += JsonUtility.ToJson(log_list[i]) + "]}";
        //    else
        //        c_string += JsonUtility.ToJson(log_list[i]) + ", ";
        //}

        File.WriteAllText("conversation_log.json", c_string);
    }

    void OnApplicationQuit()
    {
        Debug.Log("Logging Conversations...");

        recordAnalytics();

        Debug.Log("Successfully logged Conversations!");
    }
}
