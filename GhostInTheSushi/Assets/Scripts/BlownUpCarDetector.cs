using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlownUpCarDetector : MonoBehaviour {

    public UnityEngine.AI.NavMeshAgent agent;

    private TrafficVehicle vehicleInFront;

    private void OnTriggerEnter(Collider other)
    {

        var trafficAI = other.GetComponent<TrafficVehicle>();

        if (trafficAI && other.GetComponent<NavMeshAgent>().enabled == false)
        {
            vehicleInFront = trafficAI;
            agent.speed = 0.0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        var trafficAI = other.GetComponent<TrafficVehicle>();

        if (trafficAI && other.GetComponent<NavMeshAgent>().enabled == false)
        {
            vehicleInFront = trafficAI;
            agent.speed = 0.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var trafficAI = other.GetComponent<TrafficVehicle>();

        if (trafficAI && trafficAI == vehicleInFront)
        {
            vehicleInFront = null;
            agent.speed = 3.5f;
        }
    }

    void FixedUpdate()
    {
        // If the vehicle in front is deleted then continue
        if (vehicleInFront == null)
            agent.speed = 3.5f;
    }
}