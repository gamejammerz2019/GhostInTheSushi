using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ChangeSceneCollideTrigger : MonoBehaviour
{
    public string tag = "House";
    public int sceneNumberEnd = 3;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("House Colision");
        if (other.gameObject.tag == tag)
        {
            
            SceneManager.LoadScene(sceneNumberEnd);
        }
    }
}
