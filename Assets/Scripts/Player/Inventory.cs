using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// ************************************************************************************
// JSON Object Class
// ************************************************************************************
[System.Serializable]
public class JItem
{
    public int item_id;
    public string item_name;
}


// ************************************************************************************
// JSON Object List Class
// ************************************************************************************
[System.Serializable]
public class JItem_list
{
    public JItem[] item_list;
}

public class Inventory : MonoBehaviour
{
    [Tooltip("The JSON file for the item list.")]
    public TextAsset json_file_name;

    [Tooltip("UI Text for obtaining item.")]
    public GameObject item_obtained_ui;

    [Tooltip("Amount of time the UI message is displayed.")]
    public float delay = 4.0f;

    private JItem[] items_in_json;
    private List<JItem> player_inventory;
    private bool timer_on = false;
    private float timer_start;

    /// <summary>
    /// Gives the player the requested item
    /// </summary>
    /// <param name="i_id">: the item id</param>
    public void GiveItem(int i_id)
    {
        JItem new_item = items_in_json[i_id];

        if (!player_inventory.Contains(new_item))
        {
            // TODO: Add SFX!

            timer_start = Time.time;
            timer_on = true;
            item_obtained_ui.GetComponent<TMP_Text>().text = "Obtained " + new_item.item_name;
            item_obtained_ui.SetActive(true);
            player_inventory.Add(new_item);
        }
    }

    /// <summary>
    /// Checks whether the target item is in the player's inventory
    /// </summary>
    /// <param name="i_id">: the item id</param>
    /// <returns>: the result</returns>
    public bool CheckForItem(int i_id)
    {
        JItem new_item = items_in_json[i_id];

        if (player_inventory.Contains(new_item))
            return true;
        else
            return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        items_in_json = JsonUtility.FromJson<JItem_list>(json_file_name.text).item_list;
        player_inventory = new List<JItem>();
    }

    private void Update()
    {
        if (timer_on && Time.time - timer_start >= delay)
        {
            timer_on = false;
            item_obtained_ui.SetActive(false);
        }
    }
}
