using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum State { Alive, Dying };

[RequireComponent(typeof(Rigidbody))]
public class Destroyable : MonoBehaviour, IPointerClickHandler {
    private Rigidbody rb;
    private Collider col;

    public State state { get; private set; }

    // how long it takes to die, in seconds.
    public float deathDuration = 3.0f;

    // rubble effect to be displayed as the building collapses.
    public GameObject rubble;

    void Start () {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    void Update () {

    }

    void FixedUpdate () {
        switch (state) {
            case State.Alive:
                break;
            case State.Dying:
                dying();
                break;
        }
    }

    public void die () {
        // destroy, eventually.
        Destroy(gameObject, deathDuration);

        // sink into the gound.
        float yvel = (col.bounds.size.y * 1.1f) / deathDuration;
        rb.velocity = Vector3.down * yvel;

        // spawn some rubble.
        if (rubble != null) {
            Vector3 pos = transform.position;
            pos.y -= col.bounds.size.y * 0.4f;
            GameObject rbl = (GameObject)Instantiate(rubble, pos, new Quaternion());
            Destroy(rbl, deathDuration);
        }
    }

    public void dying () {
        // add some horizontal jitter.
        Vector3 jitter = Random.onUnitSphere;
        rb.velocity = new Vector3(jitter.x,
                                  rb.velocity.y,
                                  jitter.z);
    }

    public void OnPointerClick (PointerEventData eventData) {
        // if we're clicked, demolish ourselves.
        if (state == State.Alive) {
            state = State.Dying;
            die();
        }
    }
}
