using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AnimationObject))]
public class Object : MonoBehaviour
{
    [SerializeField] private float changer;
    [SerializeField] private float hunger;
    [SerializeField] private float punk;

    private AnimationObject animation;

    void Start()
    {
        animation = GetComponent<AnimationObject>();
    }

    public void HitObject(PlayerPunkHungerManager player)
    {
        if (hunger > 0 || punk > 0)
            for (int i = 0; i < changer; i++)
            {
                if (hunger > 0)
                {
                    hunger--;
                    player.ChangeHunger(1);
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
