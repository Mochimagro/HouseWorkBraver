using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
	
	public GameObject objectWeaponHitEffect;

	private ParticleSystem weaponHitEffect;
	private BoxCollider boxCollider;
	
	
	private void Start() {
		boxCollider = GetComponent<BoxCollider>();
		weaponHitEffect = objectWeaponHitEffect.GetComponent<ParticleSystem>();
		boxCollider.enabled = false;
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Monster")){
			var eff = Instantiate(weaponHitEffect,transform.position,Quaternion.identity);
		}
	}
}
