using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour {

	private int braverExp;
	private int nextExp = 500;
	public TextMeshProUGUI TextExp;

	private void Start() {
		braverExp = 0;
		SetExpText();
	}

	public void AddEXP(int value){
		braverExp += value;
		SetExpText();
	}

	private void SetExpText(){
		TextExp.text = braverExp + " / " + nextExp;
	}

}
