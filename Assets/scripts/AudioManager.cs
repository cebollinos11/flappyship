using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum AudioClipsType
{
    onHighlight,onInteract,bossTeleport
}


public class AudioManager : Singleton<AudioManager>
{
    AudioSource mainAudioSource;
    AudioSource randompitchAudioSource;
  

    [SerializeField]
    List<AudioClip> backgroundSongs;


    public static void PlayClip(AudioClip clip,float volume)
    {
        Instance.mainAudioSource.PlayOneShot(clip,volume);

    }

    public static void PlayClipRandomPitch(AudioClip clip, float volume, float pitch)
    {
        Instance.randompitchAudioSource.pitch = Mathf.Lerp(0.5f, 1.5f,pitch/10);
        Instance.randompitchAudioSource.PlayOneShot(clip, volume);

    }

    public static void PlayBgSong(int i)
    {

        //Instance.mainAudioSource.PlayOneShot(Instance.backgroundSongs[i]);
        Instance.mainAudioSource.clip = Instance.backgroundSongs[i];
        Instance.mainAudioSource.loop = true;
        Instance.mainAudioSource.Play();

    }

    public static void AudioShutdown()
    {
        StopAll();
        PlayBgSong(1);
    }

    public static void StopAll()
    {
        Instance.mainAudioSource.Stop();
    }

    // Use this for initialization
    void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        mainAudioSource = transform.GetComponent<AudioSource>();

        randompitchAudioSource = gameObject.AddComponent<AudioSource>();
       
        PlayBgSong(0);

    }




}