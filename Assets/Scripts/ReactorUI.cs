using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReactorUI : MonoBehaviour
{
    [SerializeField]
    private NuclearReactor reactor;

    [SerializeField]
    private TextMeshProUGUI reactorT, coolantT, coolantP;
    

    public void TextUpdate()
    {
        reactorT.text = $"{string.Format("{0:f1}", reactor.current_temperature)} °C";
        coolantP.text = $"{string.Format("{0:f1}", reactor.current_pressure)}áàð";
        coolantT.text = $"{string.Format("{0:f1}", reactor.current_temperature + 25)} °C";
    }
}
