using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskBoard : MonoBehaviour
{
    [SerializeField]
    private Scenario scenario;
    [SerializeField] 
    private TextMeshProUGUI currentTask;

    private void Start()
    {
        SetCurrentTaskText();
        scenario.CompleteUsualTask += SetCurrentTaskText;
        scenario.CompleteUsualTask += HideTaskText;
    }

    public void SetCurrentTaskText()
    {
        currentTask.text = scenario.GetCurrentTask();
    }

    public void ShowTaskText()
    {
        currentTask.gameObject.SetActive(true);
        scenario.AddScore(-7);
    }

    private void HideTaskText()
    {
        currentTask.gameObject.SetActive(false);
    }
}
