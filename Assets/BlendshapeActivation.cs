using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendshapeActivation : MonoBehaviour
{
    public BlendshapeDriver driver;
    public Animator animator;
    
    

    public void EmotionTriggered()
    {
        driver.enabled = false;
        animator.enabled = true;
    }

    public void DefaultTriggered()
    {
        driver.enabled = true;
        animator.enabled = false;
    }
    
}
