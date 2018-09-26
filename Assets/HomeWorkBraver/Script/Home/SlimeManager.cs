using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeManager : MonoBehaviour {

	public GameObject effectKnockdoun;
	public int exp = 0;
	private void Start() {
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Weapon")){
			KnockDown();
		}
	}

	

	public void KnockDown(){
		Destroy(gameObject);
		var eff = Instantiate(effectKnockdoun,transform.position,Quaternion.identity);
		GameObject.Find("GameManager").GetComponent<HomeManager>().AddEXP(exp);
	}

}
