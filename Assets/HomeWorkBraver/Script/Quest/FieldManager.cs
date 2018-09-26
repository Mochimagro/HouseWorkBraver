using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour {

	public GameObject Right,Center,Left;

	private void Start() {
		var animR = Right.GetComponent<Animator>();
		animR.Play("Move@Field",-1,0);

		var animC = Center.GetComponent<Animator>();
		animC.Play("Move@Field",-1,1f/3);

		var animL = Left.GetComponent<Animator>();
		animL.Play("Move@Field",-1,2f/3);
	}

}
