using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeManager : MonoBehaviour {

	private GameObject effectKnockdoun;

	private void Start() {
		effectKnockdoun = (GameObject) Resources.Load("Effect/EffectKnockdown");
	}

	public void KnockDown(){
		Destroy(gameObject);
		var eff = Instantiate(effectKnockdoun,transform.position,Quaternion.identity);
	}

}
