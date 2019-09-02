using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator animator;
    
    public void TriggerAnimator(string trigger)
    {
        animator.enabled = true;
        animator.SetTrigger(trigger);
    }
}
