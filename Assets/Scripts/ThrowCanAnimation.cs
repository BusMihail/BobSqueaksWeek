using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCanAnimation : MonoBehaviour
{
    private new Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        animator.SetBool("PlayThrowCan", true);
    }
}
