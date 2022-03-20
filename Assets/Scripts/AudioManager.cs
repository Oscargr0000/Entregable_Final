using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private AudioSource MainMenuAudioSource;
    public AudioClip[] Sound;
    // Start is called before the first frame update
    void Start()
    {
        MainMenuAudioSource = FindObjectOfType<AudioSource>();
        PlaySound(4);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int SoundNum)
    {
        MainMenuAudioSource.PlayOneShot(Sound[SoundNum], 1);
    }
}
