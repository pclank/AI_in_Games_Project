using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject smashHint;
    public GameObject openHint;
    public GameObject bothHint;

    public void ShowSmashHint()
    {
        smashHint.gameObject.SetActive(true);
    }

    public void ShowOpenHint()
    {
        openHint.gameObject.SetActive(true);
    }

    public void ShowBothHint()
    {
        bothHint.gameObject.SetActive(true);
    }

    public void HideHints()
    {
        smashHint.gameObject.SetActive(false);
        openHint.gameObject.SetActive(false);
    }
}
