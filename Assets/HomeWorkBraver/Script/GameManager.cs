using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour {

	private int braverExp;
	private int nextExp = 10;
	private int braverLevel = 1;
	public TextMeshProUGUI TextExp;
	public TextMeshProUGUI TextLevel;

	private void Start() {
		braverExp = 0;
		nextExp = 10;
		braverLevel = 1;
		SetExpText();
		SetLevelText();
	}

	public void AddEXP(int value){
		braverExp += value;
		if(braverExp >= nextExp){
			LevelUp();
		}
		SetExpText();
	}

	private void SetExpText(){
		TextExp.text = braverExp + " / " + nextExp;
	}

	private void SetLevelText(){
		TextLevel.text = "Lv." + braverLevel;
	}

	private void LevelUp(){
		braverExp -= nextExp;
		braverLevel++;
		nextExp += 50;
		if(braverExp >= nextExp){
			LevelUp();
		}
		SetLevelText();
	}

}
