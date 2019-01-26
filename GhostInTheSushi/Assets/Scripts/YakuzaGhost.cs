using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YakuzaGhost : MonoBehaviour
{

    public GameObject FamilyMember;

    public float MaxDistance = 5;
    public float DistanceToFamily;

    public UnityEngine.AI.NavMeshAgent agent;

    public float FollowSpeed;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        var heading = FamilyMember.transform.position - agent.transform.position;
        DistanceToFamily = heading.magnitude;

        if (DistanceToFamily <= MaxDistance)
        {
            agent.SetDestination(FamilyMember.transform.position);
            agent.speed = FollowSpeed;
            //YakuzaGhost.GetComponent<Animation>.Play("running");
        }
        else
        {
            agent.speed = 0;
            //YakuzaGhost.GetComponent<Animation>.Play("idle");

        }
    }

}