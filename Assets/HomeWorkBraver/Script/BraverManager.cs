using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BraverManager : MonoBehaviour {

	public GameObject target;
	public GameObject weapon;
	private BoxCollider weaponCollider;
	
	private NavMeshAgent agent;
	private Animator animator;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		animator.speed = 1.5f;
		weaponCollider = weapon.GetComponent<BoxCollider>();
		weaponCollider.enabled = false;

        // ターゲットの位置を目的地に設定する。
        //ChangeNavTarget(target);
    }

	void Update () {

		animator.SetFloat("Speed",agent.velocity.magnitude);

		if(Input.GetMouseButtonDown(0)){
			CliskAction();
		}

		if(Input.GetMouseButton(0) && target == null){
			Debug.Log("drag");
		}
		
	}

	private void OnCollisionEnter(Collision other) {
		
		AtackSlime(other.gameObject);
	}

	

	private void CliskAction(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast(ray,out hit)){
				var target = hit.collider.gameObject;
				switch(target.tag){
					case "Slime":
						ChangeNavTarget(target);
						break;

					default:
						ChangeNavTarget(hit.point);
						break;
				}
			}
	}


	private void ChangeNavTarget(GameObject target){
		if(target == null){
			agent.ResetPath();
			this.target = null;
			return;
		}
		this.target = target;
		agent.destination = target.transform.position;
	}

	private void ChangeNavTarget(Vector3 targetPosition){
		this.target = null;
		agent.destination = targetPosition;
	}

	private void AtackSlime(GameObject other){
		if(target == other){
			animator.SetTrigger("Attack");
			
		}
	}

	private void Hit(){
		target.GetComponent<SlimeManager>().KnockDown();
		ChangeNavTarget(null);
	}

	private void HittingAtack(){
		weaponCollider.enabled = true;
	}

	private void FinishAtack(){
		weaponCollider.enabled = false;
	}

}
