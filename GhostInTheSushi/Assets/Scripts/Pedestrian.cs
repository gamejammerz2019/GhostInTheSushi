using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour {

    public GameObject Target;

    private UnityEngine.AI.NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(Target.transform.position);
    }
}
