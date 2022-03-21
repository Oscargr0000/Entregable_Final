using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //This MonoBehaviour is connectet with other Scripts and allow them to play the sound we can find in the inspector

    //Sounds
    private AudioSource MainMenuAudioSource;
    public AudioClip[] Sound;
    

    void Start()
    {
        MainMenuAudioSource = FindObjectOfType<AudioSource>();

        //OST
        PlaySound(4);

    }

    public void PlaySound(int SoundNum)
    {
        //General Sounds
        MainMenuAudioSource.PlayOneShot(Sound[SoundNum], 1);
    }
}
