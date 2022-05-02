using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScripter : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource musicSource;

    private AudioClip[] audioMusicClips;
    private int _nowClipIndex;

    private void Start()
    {
        audioMusicClips = Resources.LoadAll<AudioClip>("Musics/");
        _nowClipIndex = -1;
        PlayMusic();
    }

    private void Update()
    {
        Invoke("PlayMusic", musicSource.clip.length - musicSource.time);
    }

    private int Randomize()
    {
        int num = Random.Range(0, audioMusicClips.Length);

        while (num == _nowClipIndex)
            num = Random.Range(0, audioMusicClips.Length);

        _nowClipIndex = num;
        return num;
    }

    private void PlayMusic()
    {
        int index = Randomize();
        musicSource.clip = audioMusicClips[index];
        musicSource.Play();
    }

    public void PlaySoundOneShot(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
