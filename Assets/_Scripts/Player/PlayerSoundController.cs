using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CustomFunctions;

public class PlayerSoundController : MonoBehaviour
{
    public AudioSource uiAudioSource;
    public AudioSource playerAudioSource;

    [SerializeField] private string[] uiSoundNames = new string[0];
    [SerializeField] private AudioClip[] uiSoundArr = new AudioClip[0];
    public Dictionary<string, AudioClip> uiSoundClips = new Dictionary<string, AudioClip>();


    private void Awake()
    {
        int range = Min(uiSoundNames.Length, uiSoundArr.Length);

        for (int i = 0; i < range; i++)
        {
            uiSoundClips.Add(uiSoundNames[i], uiSoundArr[i]);
        }

        if (uiSoundNames.Length != uiSoundArr.Length)
        {
            print("different number of ui sound names to ui sounds, taking all existing pairs");
        }
    }

    public void PlayUISound(string soundName)
    {
        if (uiSoundClips.ContainsKey(soundName))
        {
            uiAudioSource.clip = uiSoundClips[soundName];
            uiAudioSource.Play();
            return;
        }

        print(soundName + " is not a valud sound name");
    }

    public void StartWalkingLoop()
    {
        print("start walk audio");
        playerAudioSource.Play();
    }

    public void StopWalkingLoop()
    {
        print("stop walk audio");
        playerAudioSource.Stop();
    }
}
