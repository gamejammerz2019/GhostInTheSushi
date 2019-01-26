using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PhysicsRaycaster))]
public class Player : MonoBehaviour {
    public float moveSpeed = 0.1f;
    public float minX, width;
    public float minZ, height;
    public float typhoonHoldTime = 3.0f;
    public float typhoonCooldown = 10.0f;

    public GameObject typhoon;

    private float heldTime = 0f;
    private bool typhoonInCooldown = false;
    private float typhoonCooldownTime = 0f;

    // Start is called before the first frame update
    void Start () {
        typhoonCooldownTime = Time.time - typhoonCooldown;
    }

    // Update is called once per frame
    void Update () {
        move();
        mouse();
    }

    // player movement.
    void move () {
        Vector3 vel = Vector3.zero;

        // get player input.
        vel.x = Input.GetAxis("Horizontal") * moveSpeed;
        vel.z = Input.GetAxis("Vertical") * moveSpeed;

        // make sure we don't go faster when going diagonally.
        vel = Vector3.ClampMagnitude(vel, moveSpeed);

        Vector3 pos = transform.position;
        pos += vel;

        // make sure we don't exceed the set bounds.
        pos.x = Mathf.Clamp(pos.x, minX, minX + width);
        pos.z = Mathf.Clamp(pos.z, minZ, minZ + height);

        transform.position = pos;
    }

    // react to the player's mouse.
    void mouse () {
        if (Input.GetMouseButton(0)) {
            if (Time.time - typhoonCooldownTime > typhoonCooldown) {
                heldTime += Time.deltaTime;
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            if (heldTime > typhoonHoldTime) {
                makeTyphoon();
                typhoonInCooldown = true;
                typhoonCooldownTime = Time.time;
            }
            heldTime = 0;
        }
    }

    void makeTyphoon () {
        if (typhoon != null) {
            Vector3 typhoonOffset = new Vector3(
                    20, -transform.position.y, 0);

            GameObject spawnedTyphoon = (GameObject)Instantiate(
                    typhoon,
                    transform.position + typhoonOffset,
                    Quaternion.identity);

            spawnedTyphoon.transform.parent = transform;
        }
    }
}
