using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ChangeSceneCollideTrigger : MonoBehaviour
{
    [SerializeField] public string loadLevel;

    public string tag = "House";

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("House Colision");
        if (other.gameObject.tag == tag)
        {
            
            Application.LoadLevel(loadLevel);
        }
    }
}
