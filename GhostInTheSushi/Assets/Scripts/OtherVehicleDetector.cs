using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherVehicleDetector : MonoBehaviour {

    public TrafficVehicle Vehicle;

    private TrafficVehicle vehicleInFront;

    private void OnTriggerEnter(Collider other)
    {
      
        var trafficAI = other.GetComponent<TrafficVehicle>();

        if (trafficAI && Vector3.Dot(transform.forward,other.transform.forward) > -0.5)
        {
            Vehicle.Stop(this.gameObject);
            vehicleInFront = trafficAI;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var trafficAI = other.GetComponent<TrafficVehicle>();

        if (trafficAI && trafficAI == vehicleInFront)
        {
            vehicleInFront = null;
            Vehicle.Continue(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        // If the vehicle in front is deleted then continue
        if (vehicleInFront == null)
            Vehicle.Continue(this.gameObject);
    }
}
