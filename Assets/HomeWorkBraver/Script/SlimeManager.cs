using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeManager : MonoBehaviour {

	public GameObject effectKnockdoun;

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Weapon")){
			Debug.Log("Hit");
			KnockDown();
		}
	}

	public void KnockDown(){
		Destroy(gameObject);
		var eff = Instantiate(effectKnockdoun,transform.position,Quaternion.identity);
	}

	
	

}
