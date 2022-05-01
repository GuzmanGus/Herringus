using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationObject : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void AnimHit()
    {
        Debug.Log("Animation hit");
        //animator.SetBool(0, true);
    }

    public void CloseAnim()
    {
        animator.SetBool(0, false);
    }
}
