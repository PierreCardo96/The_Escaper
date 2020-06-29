using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    List<Sound> sounds = new List<Sound>();
    public static AudioManager Instance = null;
    private void Awake()
    {
        if (FindObjectsOfType<AudioManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

        SetAudioSources();
    }

    private void SetAudioSources()
    {
        foreach (Sound sound in sounds)
        {
            sound.AudioSource = gameObject.AddComponent<AudioSource>();
            sound.AudioSource.clip = sound.Clip;
            sound.AudioSource.volume = sound.Volume;
            sound.AudioSource.pitch = sound.Pitch;
            sound.AudioSource.loop = sound.Loop;
        }
    }
    
    public void StopMusicsForLoading()
    {
        sounds.FindAll(s => s.Name != "Bell" && s.Name != "Background").ForEach(s => s.AudioSource.Stop());
    }

    public void StopAllMusics()
    {
        sounds.ForEach(s => s.AudioSource.Stop());
    }

    public void Play(string name)
    {
        Sound sound = sounds.Find(s => s.Name == name);
        sound?.AudioSource.Play();
    }
}
