using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationObject : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AnimHit()
    {
        //Debug.Log("Anim hit");
        animator.SetBool("Hit", true);
    }

    public void CloseAnim()
    {
        animator.SetBool("Hit", false);
    }
}
