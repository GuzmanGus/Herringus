using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Object : MonoBehaviour
    {
        //[SerializeField] private Light _objectLight;
        [SerializeField] private float changer;
        [SerializeField] private float hunger;
        [SerializeField] private float punk;

        //private Animator _objectAnimator;

    private void Start()
        {
            //_objectAnimator = GetComponent<Animator>();
        }
    //public void HitObject(PlayerPunkHungerManager player)
    public void HitObject()
    {
            if (hunger > 0 || punk > 0)
                for (int i = 0; i < changer; i++)
                {
                    if (hunger > 0)
                    {
                        hunger--;
                        //player.ChangeHunger(1);
                    }

                    if (punk > 0)
                    {
                        punk--;
                        //player.ChangePunk(1);
                    }
                }
        //_objectAnimator.SetTrigger("Hit");
        Debug.Log("Hit");
        }
    }
