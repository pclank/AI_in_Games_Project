using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class MainLog
{
    // Timestamp
    public string timestamp;

    // Conversation metrics
    public float conversation_time;
    public int aggressive_count;
    public int diplomatic_count;
    public int deceptive_count;

    // Level time metrics
    public float conv_tut_time;
    public float nav_tut_time;
    public float machine_lvl_time;
    public float npc_lvl_time;
    public float push_lvl_time;
    public float apartment_lvl_time;

    // Level boolean metrics
    public int npc_lvl_choice;

    // Mechanic specific metrics
    public int push_count;

    public MainLog()
    {
        this.conversation_time = 0.0f;
        this.aggressive_count = 0;
        this.diplomatic_count = 0;
        this.deceptive_count = 0;

        this.conv_tut_time = 0.0f;
        this.nav_tut_time = 0.0f;
        this.machine_lvl_time = 0.0f;
        this.npc_lvl_time = 0.0f;
        this.push_lvl_time = 0.0f;
        this.apartment_lvl_time = 0.0f;

        this.npc_lvl_choice = -1;

        this.push_count = 0;
    }
}

public class MasterLog : MonoBehaviour
{
    public MainLog main_log;

    /// <summary>
    /// Log Conversation Choice
    /// </summary>
    /// <param name="id">: dialogue_id NOT USED</param>
    /// <param name="choice">: choice type string</param>
    public void LogChoice(int id, string choice)
    {
        if (choice == "aggressive")
            main_log.aggressive_count++;
        else if (choice == "diplomatic")
            main_log.diplomatic_count++;
        else if (choice == "deceptive")
            main_log.deceptive_count++;
        else
            Debug.LogError("Wrong choice type detected!");

        Debug.Log(choice + " Added to Log");
    }

    /// <summary>
    /// Update Conversation Time
    /// </summary>
    /// <param name="time">: the time the player spent on the current conversation</param>
    public void UpdateTimeLog(float time)
    {
        main_log.conversation_time += time;

        Debug.Log(time + " Added to Log");
    }

    /// <summary>
    /// Write Log to JSON file (runs automatically on game exit)
    /// </summary>
    public void WriteLog()
    {
        // Write timestamp
        main_log.timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

        // Check for folder
        if (!Directory.Exists("PlayerLogs"))
        {
            Debug.Log("PlayerLogs folder not found. Creating...");
            Directory.CreateDirectory("PlayerLogs");
        }


        string c_string = JsonUtility.ToJson(main_log);

        File.WriteAllText("PlayerLogs/main_log.json", c_string);
    }

    /// <summary>
    /// Parse existing JSON file (can be used if levels are in separate scenes)
    /// </summary>
    public void ParseLog()
    {
        string text_file = File.ReadAllText("PlayerLogs/main_log.json");
        main_log = JsonUtility.FromJson<MainLog>(text_file);
    }

    void OnApplicationQuit()
    {
        Debug.Log("Creating Log...");

        WriteLog();

        Debug.Log("Successfully written Log!");
    }
}
