using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TrafficVehicle))]
public class Crashable : MonoBehaviour, IPointerClickHandler {

    public enum State { Alive, Crashing, Crashed };

    public float crashDuration = 2.0f;
    public float initialSpin = 5.0f;

    public GameObject fireParticles;

    public State state { get; private set; }

    /* TODO #finish: use the navmesh agent instead? */
    private TrafficVehicle tv;
    private Rigidbody rb;
    private UnityEngine.AI.NavMeshAgent ag;

    private float crashTime;

    void Start () {
        tv = GetComponent<TrafficVehicle>();
        rb = GetComponent<Rigidbody>();
        ag = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void FixedUpdate () {
        switch (state) {
            case State.Alive:
                break;
            case State.Crashing:
                crashing();
                break;
            case State.Crashed:
                break;
        }
    }

    public void crashed () {
        state = State.Crashed;

        // add a fire.
        GameObject fire = (GameObject)Instantiate(fireParticles, transform.position, new Quaternion());
    }

    public void crashing () {
        float crashFraction = (Time.time - crashTime) / crashDuration;

        // check if we've finished the crash procedure.
        if (crashFraction > 1) {
            crashed();
            return;
        }

        // dampen speed.
        float velDamp = 0.2f;
        float newVel = Mathf.Max(rb.velocity.magnitude - velDamp, 0f);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, newVel);

        // dampen rotation.
        transform.Rotate(Vector3.up, initialSpin * (1 - crashFraction));
    }

    public void crash () {
        state = State.Crashing;

        // stop acting as an ai-based traffic vehicle.
        tv.enabled = false;
        ag.enabled = false;

        // record the time at which we crashed.
        crashTime = Time.time;
    }

    public void OnPointerClick (PointerEventData eventData) {
        if (state == State.Alive) {
            // if we're clicked, crash ourselves.
            crash();
        }
    }
}
