using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {

	public float speed = 5f;
	public GameObject effectKnockdown;

	private void Update() {
		transform.localPosition += transform.forward * speed * Time.fixedDeltaTime;
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Weapon")){
			KnockDown();
		}
	}

	private void KnockDown(){
		Destroy(gameObject);
		var eff = Instantiate(effectKnockdown,transform.position,Quaternion.identity);

	}

}
