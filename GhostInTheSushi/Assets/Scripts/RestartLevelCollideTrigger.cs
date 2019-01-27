using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.IO;

public class RestartLevelCollideTrigger : MonoBehaviour {

    public NavMeshAgent agent;

    private Scene scene;
    public string tag = "FamilyMember";
    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {

        if (other.gameObject.tag == tag && agent.speed != 0.0f)
        {
            Debug.Log("Reload Level");
            Application.LoadLevel(scene.name);
        }	
	}

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == tag && agent.speed != 0.0f)
        {
            Debug.Log("Reload Level");
            Application.LoadLevel(scene.name);
        }
    }
}
