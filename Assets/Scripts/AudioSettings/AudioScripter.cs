using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StaticAudioSettings;
using UnityEngine.SceneManagement;

public class AudioScripter : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private List<AudioClip> audioMusicClips = new List<AudioClip>();

    //private AudioClip[] audioMusicClips; //see serializefield audiomusicsClips
    private int _nowClipIndex;

    private void Start()
    {
        audioSource.volume = StaticAudioSettings.soundVolume;
        musicSource.volume = StaticAudioSettings.musicVolume;

        //audioMusicClips = Resources.LoadAll<AudioClip>("Musics/"); //see serializefield audiomusicsClips
        _nowClipIndex = -1;
        PlayMusic();
    }

    private void Update()
    {
        if (musicSource != null)
        {
            Invoke("PlayMusic", musicSource.clip.length - musicSource.time);
        }
        //Баг при вызове метода SetNewDay - был пофиксен с помощью проверки на null
    }

    /*private int Randomize()
    {
        int num = Random.Range(0, audioMusicClips.Length);

        while (num == _nowClipIndex)
            num = Random.Range(0, audioMusicClips.Length);

        _nowClipIndex = num;
        return num;
    }*/

    private void ChooseMusic()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        if (index == 0)
        {
            musicSource.clip = audioMusicClips[0];
        }
        else if (index == 1)
        {
            musicSource.clip = audioMusicClips[1];
        }
        else if (index == 2)
        {
            musicSource.clip = audioMusicClips[2];
        }
        else
        { 
            musicSource.clip = audioMusicClips[1]; //choose default music
        }
    }

    private void PlayMusic()
    {
        //int index = Randomize();
        //musicSource.clip = audioMusicClips[index];
        ChooseMusic();
        musicSource.Play();
    }

    public void PlayMusicGoodFinal()
    {
        musicSource.clip = audioMusicClips[3]; //good music 
    }
    public void PlayMusicBadFinal()
    {
        musicSource.clip = audioMusicClips[4]; //bad music
    }

    public void PlaySoundOneShot(AudioClip audioClip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    } 
}
