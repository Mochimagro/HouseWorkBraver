using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffectManager : MonoBehaviour {

	public ParticleSystem tapEffect;
	public Camera effectCamera;

	private void Start() {
		
	}

	private void Update() {
		if(Input.GetMouseButtonDown(0)){
			var pos = effectCamera.ScreenToWorldPoint(Input.mousePosition +  effectCamera.transform.forward * 10);//
			tapEffect.transform.position = pos;
			tapEffect.Emit(Random.Range(4,7));
		}
	}

}
