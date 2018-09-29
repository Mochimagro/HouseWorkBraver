using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {

	public int hp = 5;
	public int atk = 5;

	public float speed = 5f;
	public GameObject effectKnockdown;
	public GameObject effectAttackMonster;
	private Rigidbody rbody;
	private bool onFloor;
	private BraverQuestManager braver;

	private void Start(){
		rbody = GetComponent<Rigidbody>();
		rbody.AddForce(transform.forward * speed);
		braver = GameObject.FindGameObjectWithTag("Braver").GetComponent<BraverQuestManager>();
		onFloor = true;
	}

	private void Update() {
		
	}

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.CompareTag("Field")){
			if(!onFloor){
				onFloor = true;
				rbody.Sleep();
				rbody.AddForce(transform.forward * speed);
			}
		}
		if(other.gameObject.CompareTag("Braver")){
			var pos = other.transform.position;
			pos.y += 2f;
			Instantiate(effectAttackMonster,pos,Quaternion.identity);
			braver.Damage(atk);
			KnockBack();
		}

	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Weapon")){
			if(onFloor){
				Damage(braver.atk);
				//Damage(GetComponent<BraverQuestManager>().atk);
			}
			
		}
	}
	

	public void Damage(int atk){
		hp -= atk;
		if(hp > 0){
			KnockBack();
		}else{
			KnockDown();
		}
	}

	private void KnockDown(){
		Destroy(gameObject);
		var eff = Instantiate(effectKnockdown,transform.position,Quaternion.identity);

	}

	private void KnockBack(){
		if(!onFloor){
			return;
		}
		onFloor = false;
		GetComponent<Rigidbody>().AddForce(new Vector3(2f,1f,0) * 200);
	}

}
