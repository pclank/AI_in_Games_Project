using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelLog
{
    public string level_name;

    public float navigation_time;

    public LevelLog(string name)
    {
        this.level_name = name;

        this.navigation_time = Time.time;
    }
}

public class LogLevel : MonoBehaviour
{
    [Tooltip("Length of List that Triggers Data Export.")]
    public int max_length = 5;

    private List<LevelLog> log_list = new List<LevelLog>();     // List of Logging Events

    // Add Analytics to List
    public void addAnalytics(string name)
    {
        log_list.Add(new LevelLog(name));

        Debug.Log(name + " Added to Analytics");

        if (log_list.Count == max_length)
            recordAnalytics();
    }

    // Record Analytics List to JSON File
    private void recordAnalytics()
    {
        string c_string = "{\"level_log\": [" + JsonUtility.ToJson(log_list[0]) + ", ";

        for (int i = 1; i < log_list.Count; i++)
        {
            if (i == log_list.Count - 1)
                c_string += JsonUtility.ToJson(log_list[i]) + "]}";
            else
                c_string += JsonUtility.ToJson(log_list[i]) + ", ";
        }

        File.WriteAllText("level_log.json", c_string);
    }
}
