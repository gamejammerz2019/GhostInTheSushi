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
    public float deathDelay = 30.0f;

    public GameObject fireParticles;

    public State state { get; private set; }

    private TrafficVehicle tv;
    private Rigidbody rb;
    private UnityEngine.AI.NavMeshAgent ag;

    private float crashTime;
    private float initialSpeed;
    private Vector3 initialDirection;

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
        float secondsSinceDeath = Time.time - crashTime;
        Destroy(fire, deathDelay - secondsSinceDeath);
    }

    public void crashing () {
        float crashFraction = (Time.time - crashTime) / crashDuration;

        // check if we've finished the crash procedure.
        if (crashFraction > 1) {
            crashed();
            return;
        }

        // dampen speed.
        transform.Translate(Vector3.forward * Time.deltaTime * initialSpeed * (1 - crashFraction));

        // dampen rotation -- via children, to avoid messing with our Vector3.forward.
        foreach (Transform child in transform) {
            child.Rotate(Vector3.up, initialSpin * (1 - crashFraction));
        }
    }

    public void crash () {
        state = State.Crashing;

        initialSpeed = ag.velocity.magnitude;

        // stop acting as an ai-based traffic vehicle.
        tv.enabled = false;
        ag.enabled = false;

        // record the time at which we crashed.
        crashTime = Time.time;

        // destroy ourself after a delay.
        Destroy(gameObject, deathDelay);
    }

    public void OnPointerClick (PointerEventData eventData) {
        if (state == State.Alive) {
            // if we're clicked, crash ourselves.
            crash();
        }
    }
}
