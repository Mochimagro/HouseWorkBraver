using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private int braverExp;
	private int nextExp = 10;
	private int braverLevel = 1;
	public TextMeshProUGUI TextExp;
	public TextMeshProUGUI TextLevel;
	public Slider SliderExpGauge;

	private void Start() {
		braverExp = 0;
		nextExp = 10;
		braverLevel = 1;
		SetExpText();
		SetLevelText();
		SetExpSliderMaxValue();
	}

	public void AddEXP(int value){
		braverExp += value;
		if(braverExp >= nextExp){
			LevelUp();
		}
		SetExpText();
		SetExpSlider();
	}

	private void SetExpText(){
		TextExp.text = braverExp + " / " + nextExp;
	}

	private void SetLevelText(){
		TextLevel.text = "Lv." + braverLevel;
	}

	private void SetExpSlider(){
		SliderExpGauge.value = braverExp;
	}

	private void SetExpSliderMaxValue(){
		SliderExpGauge.maxValue = nextExp;
		SetExpSlider();
	}

	private void LevelUp(){
		braverExp -= nextExp;
		braverLevel++;
		nextExp += 50;
		if(braverExp >= nextExp){
			LevelUp();
		}
		SetExpSliderMaxValue();
		SetLevelText();
	}

}
