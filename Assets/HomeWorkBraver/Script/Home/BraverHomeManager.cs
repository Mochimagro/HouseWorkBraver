using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BraverHomeManager : MonoBehaviour {

	public GameObject target;
	[SerializeField]private List<GameObject> targetList = new List<GameObject>();
	public GameObject weapon;
	private BoxCollider weaponCollider;
	
	private SphereCollider attackArea;
	private NavMeshAgent agent;
	private Animator animator;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		animator.speed = 1.5f;
		weaponCollider = weapon.GetComponent<BoxCollider>();
		weaponCollider.enabled = false;
		attackArea = GetComponent<SphereCollider>();
		attackArea.enabled = false;
		targetList.Clear();

        // ターゲットの位置を目的地に設定する。
        //ChangeNavTarget(target);
    }

	void Update () {

		animator.SetFloat("Speed",agent.velocity.magnitude);

		if(Input.GetMouseButtonDown(0)){
			CliskAction();
		}

		if(Input.GetMouseButton(0) && target == null){
			//Debug.Log("drag");
		}
		
	}

	private void OnCollisionEnter(Collision other) {
		
	}

	private void OnTriggerEnter(Collider other) {
		
		AtackSlime(other.gameObject);
	}
	
	private void CliskAction(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast(ray,out hit)){
				var target = hit.collider.gameObject;
				switch(target.tag){
					case "Slime":
						if(this.target == null){
							ChangeNavTarget(target);
							attackArea.enabled = true;
						}else{
							targetList.Add(target);
						}
						break;

					default:
						if(this.target == null){
							ChangeNavTarget(hit.point);
						}
						
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
		attackArea.enabled = true;
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
			attackArea.enabled = false;
		}
	}

	private void RefreshList(){
		int i = 0;
		while(i < targetList.Count){
			if(targetList[i] == null){
				targetList.RemoveAt(i);
			}else{
				i++;
			}
		}
	}

	private void Hit(){
		target.GetComponent<SlimeManager>().KnockDown();
	}

	private void HittingAttack(){
		weaponCollider.enabled = true;
	}

	private void FinishAttack(){
		weaponCollider.enabled = false;

		RefreshList();
		if(targetList.Count > 0){
			ChangeNavTarget(targetList[0]);
		}else{
			ChangeNavTarget(null);
		}
	}

}
