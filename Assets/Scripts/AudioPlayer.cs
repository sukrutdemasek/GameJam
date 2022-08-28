using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip SoundToPlay;
    AudioSource audio;
    public float volume = 1f;
    public bool alreadyPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!alreadyPlayed)
        {
            audio.PlayOneShot(SoundToPlay, volume);
            alreadyPlayed = true;
        }
    }
    // Update is called once per frame

}
