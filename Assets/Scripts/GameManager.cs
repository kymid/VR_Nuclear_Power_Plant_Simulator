using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private NuclearReactor reactor;
    [SerializeField]
    private ReactorUI reactorUI;


    IEnumerator MainReactorStream()
    {
        while(true)
        {
            reactor.UpdateReactorValues();
            reactorUI.TextUpdate();
            yield return new WaitForSeconds(1f);
        }

    }

    private void Start()
    {
        StartCoroutine(MainReactorStream());
    }

}
