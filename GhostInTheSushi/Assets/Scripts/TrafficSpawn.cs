using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSpawn : MonoBehaviour {

    public GameObject TrafficPrefab;

    public GameObject TrafficTarget;

    public int SpawnTime = 10;
    private float spawnTimer = 0.0f;
	
    public void SpawnTraffic()
    {
        var vehicle = (GameObject)Instantiate(TrafficPrefab, transform.position, transform.rotation);
        var trafficAI = vehicle.GetComponent<TrafficVehicle>();

        if (!trafficAI)
        {
            print("No Traffic AI on vehicle");
            return;
        }

        trafficAI.SetTarget(TrafficTarget);
    }

    void FixedUpdate()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            spawnTimer = SpawnTime;
            SpawnTraffic();
        }

    }
}
