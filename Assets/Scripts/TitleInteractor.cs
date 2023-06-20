using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleInteractor : MonoBehaviour
{
    [SerializeField] GameObject titleMesh;

    public void ShowText()
    {
        titleMesh.SetActive(true);
    }
    public void HideText()
    {
        titleMesh.SetActive(false);
    }
}
