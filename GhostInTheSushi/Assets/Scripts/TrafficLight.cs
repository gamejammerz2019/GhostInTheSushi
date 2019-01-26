using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{

    public TrafficVehicle.TrafficID TargetAgentType = TrafficVehicle.TrafficID.CAR;

    // Is the green light showing
    public bool IsGo = true;

    public Light GreenLight;
    public Light RedLight;

    public int SwapTime = 5;
    private float swapTimer = 5.0f;

    // Use this for initialization
    void Start()
    {
        UpdateLights();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        swapTimer -= Time.deltaTime;

        if (swapTimer <= 0)
        {
            swapTimer = SwapTime;
            IsGo = !IsGo;
            UpdateLights();
        }
    }

    private void UpdateLights()
    {
        GreenLight.enabled = IsGo;
        RedLight.enabled = !IsGo;
    }

    private void OnTriggerEnter(Collider other)
    {

        var trafficAI = other.GetComponent<TrafficVehicle>();

        if (trafficAI && trafficAI.TrafficType == TargetAgentType)
        {
            trafficAI.AssignTrafficLight(this);
        }
    }
}
