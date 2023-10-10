using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_Event : MonoBehaviour
{
    public string sceneToLoad = "OutdoorsScene"; // The name of the scene to load

    private void OnMouseUpAsButton()
    {
        Debug.Log("Portal Clicked");
        LoadScene();
    }

    private void LoadScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }
}