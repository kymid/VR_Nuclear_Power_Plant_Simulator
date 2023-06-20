using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tilia.Interactions.Controllables.AngularDriver;
using Tilia.Interactions.Controllables.LinearDriver;


public class NuclearReactor : MonoBehaviour
{

    [SerializeField]
    private Scenario scenario;


    [SerializeField]
    private float base_temperature, base_pressure,
                  control_rods_sensivity, coolant_flow_sensivity, heat_generation_sensivity, temperature_sensivity;

    public float current_temperature { get; private set; }
    public float current_pressure { get; private set; }

    [SerializeField]
    private AngularDriveFacade mainCoolantSystem;

    [SerializeField]
    private LinearDriveFacade controlRods;

    public float rods { get; private set;}
    public float flow { get; private set; }

    public bool isBrokenCoolantSystem, isSecondCoolantSystem, isFire;

    private float last_temperature;

    private void SetTemperature()
    {
        current_temperature += control_rods_sensivity * (rods + .1f);

        if(!isBrokenCoolantSystem)
        current_temperature -= coolant_flow_sensivity * (flow + .1f);

        if (isBrokenCoolantSystem & isSecondCoolantSystem)
        current_temperature -= 1;

        if(isFire)
        current_temperature += 1;


        current_temperature = Mathf.Clamp(current_temperature, base_temperature, 600);
    }

    private void SetPressure()
    {
        current_pressure = base_pressure + control_rods_sensivity * rods -
                           coolant_flow_sensivity * flow + temperature_sensivity * current_temperature;

        current_pressure = Mathf.Clamp(current_pressure, base_pressure, 300);
    }

    void Awake()
    {
        current_temperature = 295;
        last_temperature = current_temperature;

        current_pressure = 170;

        rods = controlRods.InitialTargetValue;
        flow = mainCoolantSystem.InitialTargetValue;
    }

    public void UpdateReactorValues()
    {
        SetTemperature();
        SetPressure();

        if(current_temperature > last_temperature)
        { 
            if (current_temperature > 360)
                scenario.AddScore(-1.9f);
            else if(current_temperature > 345)
                scenario.AddScore(-1.4f);
            else if (current_temperature > 330)
                scenario.AddScore(-.7f);
        }

        last_temperature = current_temperature;
        //Debug.Log($"{current_temperature} , {current_pressure}");
    }

    public void RodsUpdate(float value)
    {
        rods = value;
    }
    public void FlowUpdate(float value)
    {
        flow = value;
    }

}
