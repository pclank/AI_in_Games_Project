using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Image smashHint;
    public Image openHint;

    public void ShowSmashHint()
    {
        smashHint.gameObject.SetActive(true);
    }

    public void ShowOpenHint()
    {
        openHint.gameObject.SetActive(true);
    }

    public void HideHints()
    {
        smashHint.gameObject.SetActive(false);
        openHint.gameObject.SetActive(false);
    }
}
