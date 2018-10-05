using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour {

	private int braverExp;
	private int nextExp = 10;
	private int braverLevel = 1;
	public TextMeshProUGUI TextTotalExp;
	public TextMeshProUGUI TextLevel;
	public Slider SliderExpGauge;

	public Canvas CanvasUIText;
	public GameObject TextGetExp;
	public GameObject TextLevelUP;

	private DataManager dataManager;

	private void Start() {
		dataManager = GetComponent<DataManager>();

		braverExp = 0;
		nextExp = 10;
		braverLevel = 1;
		SetExpText();
		SetLevelText();
		SetExpSliderMaxValue();
	}

	public void AddEXP(int value,Transform target){
		braverExp += value;
		if(braverExp >= nextExp){
			LevelUp();
		}
		SetExpText();
		SetExpSlider();

		dataManager.DataSave(braverExp,DataName.braverEXP);

		var tmpText = Instantiate(TextGetExp);
		tmpText.transform.SetParent(CanvasUIText.transform,false);
		tmpText.GetComponent<RectTransform>().position = RectTransformUtility.WorldToScreenPoint(Camera.main,target.position);
		tmpText.GetComponent<TextMeshProUGUI>().text = "+" + value + "Exp";
		Destroy(tmpText,2f);
	}

	private void SetExpText(){
		TextTotalExp.text = braverExp + " / " + nextExp;
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
		TextLevelUP.SetActive(true);
		dataManager.DataSave(braverLevel,DataName.braverLevel);
	}

}
