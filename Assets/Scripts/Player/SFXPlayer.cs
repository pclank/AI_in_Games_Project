using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public AudioClip item_sfx;
    public AudioClip page_sfx;

    private AudioSource sfx_source;

    /// <summary>
    /// Plays selected SFX
    /// </summary>
    /// <param name="id">: 0 for item, 1 for page turning</param>
    public void PlaySFX(int id)
    {
        if (id == 0)
            sfx_source.clip = item_sfx;
        else
            sfx_source.clip = page_sfx;

        sfx_source.Play();
    }

    void Start()
    {
        sfx_source = gameObject.GetComponent<AudioSource>();
    }
}
