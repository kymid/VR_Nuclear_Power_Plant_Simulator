using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RayInteractorAnable : MonoBehaviour
{
    [SerializeField] InputActionProperty RayTriggerAction;

    [SerializeField] GameObject RayInteractor;

    [SerializeField] XRRayInteractor XRrayInteractor;


    void Update()
    {
        float triggerValue = RayTriggerAction.action.ReadValue<float>();
        bool isTrigger = triggerValue > 0f;
        RayInteractor.SetActive(isTrigger);

        if (isTrigger)
        {
            RaycastToRead();
        }
        else
        {
            lastTitle?.HideText();
        }
  
    }

    GameObject lastObj;
    TitleInteractor lastTitle;
    private void RaycastToRead()
    {
        if (!XRrayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit ray))
        {
            lastTitle?.HideText();
            return;
        }

        if (!ray.collider.gameObject.TryGetComponent(out TitleInteractor title))
        {
            lastTitle?.HideText();
            return;
        }

        if (title.gameObject == lastObj)
            title.ShowText();
        else
            lastTitle?.HideText();

        lastObj = title.gameObject;
        lastTitle = title;

    }
}
