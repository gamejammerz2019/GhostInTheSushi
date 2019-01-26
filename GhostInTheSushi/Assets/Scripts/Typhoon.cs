using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Typhoon : MonoBehaviour {
    public float lifetime = 5.0f;
    public float strength = 0.5f;

    void Start () {
        offsetGravity(x: strength);
        Destroy(gameObject, lifetime);
    }

    void OnDestroy () {
        offsetGravity(x: -strength);
    }

    void offsetGravity (float x = 0, float y = 0, float z = 0) {
        Vector3 curr_gravity = Physics.gravity;
        curr_gravity.x += x;
        curr_gravity.y += y;
        curr_gravity.z += z;
        Physics.gravity = curr_gravity;
        Debug.Log(Physics.gravity);
    }
}
