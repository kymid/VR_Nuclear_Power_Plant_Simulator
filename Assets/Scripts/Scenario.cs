using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Scenario : MonoBehaviour
{
    public delegate void CompleteTask();
    public event CompleteTask CompleteUsualTask;

    [SerializeField]
    private NuclearReactor reactor;

    [SerializeField]
    private WinMenu winMenu;

    [SerializeField]
    private List<string> allTasksText;
    [SerializeField]
    private List<string> allTasksName;

    private int currentTaskIndex = 0;
    private float score = 100;

    [SerializeField]
    private bool isRepaired;

    private bool isEnded = false;

    public enum scenaries {nasos, electro, fire };

    public scenaries currentScenaries;

    private void Start()
    {
        CompleteUsualTask += CheckWaitRepair;
        CompleteUsualTask += CheckToWinScenario;
    }
    public string GetCurrentTask()
    {
        if (allTasksText.Count > currentTaskIndex)
            return allTasksText[currentTaskIndex];
        else
            return null;
    }

    public bool CheckTaskToComplete(string taskName)
    {
        if(taskName == allTasksName[currentTaskIndex])
        {
            UpdateTaskIndex();
            AddScore(0);
            CompleteUsualTask();
            return true;
        }

        return false;
    }

    private void UpdateTaskIndex()
    {
        currentTaskIndex++;
    }

    public void AddScore(float value)
    {
        score += value;
        score = Mathf.Clamp(score, 0, 100);

        Debug.Log($"score: {score}");

        if(score <= 0)
        {
            LoseScenario();
        }
    }

    private void CheckWaitRepair()
    {
        if (isRepaired) return;

        StopAllCoroutines();
        StartCoroutine(WaitRepair());
    }
    private void CheckToWinScenario()
    {
        if (allTasksText.Count - 1 == currentTaskIndex) WinScenario();
    }

    private void WinScenario()
    {
        if (isEnded) return;

        isEnded = true;

        winMenu.transform.GetChild(0).gameObject.SetActive(true);
        winMenu.SetText(score);

        Debug.Log("WIN");
    }

    private void LoseScenario()
    {
        if (isEnded) return;

        isEnded = true;

        winMenu.transform.GetChild(0).gameObject.SetActive(true);
        winMenu.SetText(score);

        Debug.Log("LOSE");
    }

    //tasks

    private IEnumerator WaitRepair()
    {
        yield return new WaitForSeconds(20f);

        bool repaired = CheckTaskToComplete("WaitRepair");

        if (currentScenaries == scenaries.nasos)
            reactor.isBrokenCoolantSystem = !repaired;
        else if (currentScenaries == scenaries.electro)
            Debug.Log("ass");
        else if(currentScenaries == scenaries.fire)
            reactor.isFire = !repaired;


        isRepaired = repaired;
    }

    public void Reboot()
    {
        if(reactor.rods > .3f & reactor.flow > .3f)
        {
           CheckTaskToComplete("Reboot");
        }

    }
    public void GetControlRods(float value)
    {
        if(value < .02f)
        {
            CheckTaskToComplete("ONControlRods");
        }
        
    }
    public void GetCoolantSystem(float value)
    {
        if(value == 0)
        {
            if (!CheckTaskToComplete("PushCoolantSystemButton"))
                AddScore(-10);
            reactor.isSecondCoolantSystem = true;
        }
        else if(value == 1)
        {
            reactor.isSecondCoolantSystem = false;
        }

    }

    public void GetFireWaterSystem(float value)
    {
        if (value == 0)
        {
            if (!CheckTaskToComplete("FireWater"))
                AddScore(-10);
            reactor.isFire = false;
        }
       

    }

    public void GetEvacuation(float value)
    {
        if (value == 0)
        {
            if (!CheckTaskToComplete("Evacuation"))
                AddScore(-10);
        }
    }

    public void GetElectricity(float value)
    {
        if (value == 0)
        {
            if (!CheckTaskToComplete("Electricity"))
                AddScore(-10);
        }
    }

    public void GetKnob(float value)
    {
        if(value < .15f)
        {
            CheckTaskToComplete("Rotate");
        }
    }
}
