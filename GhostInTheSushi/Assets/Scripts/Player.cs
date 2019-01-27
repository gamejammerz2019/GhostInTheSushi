using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PhysicsRaycaster))]
public class Player : MonoBehaviour {
    public float horizMoveSpeed = 0.2f;
    public float vertMoveSpeed = 0.15f;
    public float minX, width;
    public float minY, height;
    public float minZ, depth;
    public float typhoonHoldTime = 3.0f;
    public float typhoonCooldown = 10.0f;

    public GameObject typhoon;

    private float heldTime = 0f;
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
        vel.x = Input.GetAxis("Horizontal") * horizMoveSpeed;
        vel.z = Input.GetAxis("Vertical") * horizMoveSpeed;

        // make sure we don't go faster when going diagonally.
        vel = Vector3.ClampMagnitude(vel, horizMoveSpeed);

        // up and down -- simpler, and doesn't affect the horizontal magnitude.
        if (Input.GetKey(KeyCode.Space)) {
            vel.y = vertMoveSpeed;
        } else if (Input.GetKey(KeyCode.LeftShift)) {
            vel.y = -vertMoveSpeed;
        }

        // apply the movement.
        Vector3 pos = transform.position;
        pos += vel;

        // make sure we don't exceed the set bounds.
        pos.x = Mathf.Clamp(pos.x, minX, minX + width);
        pos.y = Mathf.Clamp(pos.y, minY, minY + height);
        pos.z = Mathf.Clamp(pos.z, minZ, minZ + depth);

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
