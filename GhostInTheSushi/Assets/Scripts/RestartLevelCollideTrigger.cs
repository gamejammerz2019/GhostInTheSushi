using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class RestartLevelCollideTrigger : MonoBehaviour {

    private Scene scene;
    public string tag = "FamilyMember";
    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {

        if (other.gameObject.tag == tag)
        {
            Debug.Log("Reload Level");
            Application.LoadLevel(scene.name);
        }	
	}
}
