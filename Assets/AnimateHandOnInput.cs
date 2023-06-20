using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    [SerializeField] InputActionProperty pinchAnimationAction;
    [SerializeField] InputActionProperty gripAnimationAction;
    [SerializeField] Animator handAnimator;

    void Update()
    {
        float pinchValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", pinchValue);
        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
        
    }
}
