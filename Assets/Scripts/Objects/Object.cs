using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AnimationObject))]
public class Object : MonoBehaviour
{
    [SerializeField] private int multiply = 1;
    [SerializeField] private float changer;
    [SerializeField] private float hunger;
    [SerializeField] private float punk;

    [SerializeField] private AudioClip audioClip;

    private AnimationObject animation;

    void Start()
    {
        animation = GetComponent<AnimationObject>();
    }

    public void AudioHitObject(AudioScripter audioScripter)
    {
        audioScripter.PlaySoundOneShot(audioClip);
    }

    public void HitObject(PlayerPunkHungerManager player)
    {
        if (hunger > 0 || punk > 0)
            for (int i = 0; i < changer; i++)
            {
                if (hunger > 0)
                {
                    hunger--;
                    player.ChangeHunger(1 * multiply);
                }

                if (punk > 0)
                {
                    punk--;
                    player.ChangePunk(1);
                }
            }

        animation.AnimHit();
    }
}
