using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
    public GameObject Player;
    public float forwardSpeed = 5.0f;
    public float turningSpeed = 10.0f;

    // Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Player.transform.position = Player.transform.position + (Player.transform.rotation * new Vector3(0, 0, forwardSpeed)) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Player.transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, turningSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Player.transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, turningSpeed * Time.deltaTime);
        }
    }
}
