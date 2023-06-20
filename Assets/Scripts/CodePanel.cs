using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePanel : MonoBehaviour
{
    [SerializeField]
    private Scenario scenario;

    [SerializeField]
    private string password;

    [SerializeField]
    private string currentCode;
    
    public void AddNumber(string value)
    {
        currentCode += value;
    }
    public void RemoveCode()
    {
        currentCode = null;
    }            
    public void CheckCode()
    {
        if (password == currentCode)
        if(!scenario.CheckTaskToComplete("SendSecurityProtocol"))
           scenario.AddScore(-10);
        
        RemoveCode();
    }
}
