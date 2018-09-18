using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SubCharacterController : MonoBehaviour {
	public GameObject target;

	private NavMeshAgent agent;
	private Animator animator;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		animator.speed = 1.5f;

        // ターゲットの位置を目的地に設定する。
        agent.destination = target.transform.position;
    }

	void Update () {

		animator.SetFloat("Speed",agent.velocity.magnitude);

		
	}
}

