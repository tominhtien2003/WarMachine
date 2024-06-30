using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    [SerializeField] private Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private string soundUsing;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s != null)
        {
            musicSource.clip = s.audioClip;
            musicSource.Play();
            soundUsing = name;
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s != null)
        {
            sfxSource.clip = s.audioClip;
            sfxSource.PlayOneShot(s.audioClip);
            soundUsing = name;
        }
    }
    public string GetSoundUsing()
    {
        return soundUsing;
    }
    public void ResetMusicSoundUsing()
    {
        soundUsing = null;
        musicSource.clip = null;
    }
    public void ResetSFXSoundUsing()
    {
        soundUsing = null;
        sfxSource.clip = null;
    }
}
