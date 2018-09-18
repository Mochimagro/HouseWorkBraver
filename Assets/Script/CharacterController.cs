using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	public float speed = 5f;
	public float smoothRotation = 10f;
	public float animationSpeed = 1.5f;

	private Rigidbody playerRigidbody;
	private Animator animator;
	

	void Start () {
		playerRigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}
	
    

	void FixedUpdate () {
		var dh = Input.GetAxis("Horizontal");
		var dv = Input.GetAxis("Vertical");

		//var velosity = new Vector3(dh,0,dv) * speed;

		var targetVel = new Vector3(dh,0,dv);

		animator.SetFloat("Speed",targetVel.magnitude);
		animator.speed = animationSpeed;

		if(targetVel.magnitude > 0.1){
			
			Quaternion rotation = Quaternion.LookRotation(targetVel);
			transform.rotation = Quaternion.Lerp(transform.rotation,rotation,Time.deltaTime * smoothRotation);
			

			transform.localPosition += targetVel * speed * Time.fixedDeltaTime;
		}
		

	}
}
