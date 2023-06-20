using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu, scenarioMenu;
    public void SetScenarioMenu(bool yes)
    {
        mainMenu.SetActive(!yes);
        scenarioMenu.SetActive(yes);
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
