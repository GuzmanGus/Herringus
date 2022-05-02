using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObjectAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void AnimationAttack()
    {
        animator.SetBool(0, true);
    }
}
