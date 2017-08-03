using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   // << : 진입점

public class NavMeshAgent_Enemy : MonoBehaviour {

    public GameObject pTarget;
    NavMeshAgent agent;
    Animator animator;
    public Plane Floor;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }
	
	void Update () {
        if (pTarget != null)
        {
            agent.destination = pTarget.transform.position;
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
    }

    void SetTarget(GameObject Target)
    {
        pTarget = Target;
    }
}
