using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour {

	public int BraverHP;
	private int BraverMaxHP;
	public int BraverAtk;
	private int whiteJewels;



	public TextMeshProUGUI textHp;
	public Slider sliderHpGauge;
	public GameObject TextBraverDamage;
	public GameObject TextMonsterDamage;
	public Canvas CanvasUI;
	private GameObject braverObject;
	private BraverQuestManager braverQuestManager;

	private Vector3 braverPosRect;

	public TextMeshProUGUI textWhiteJewels;

	private void Start() {
		braverObject = GameObject.FindGameObjectWithTag("Braver");
		braverQuestManager = braverObject.GetComponent<BraverQuestManager>();
		braverPosRect = RectTransformUtility.WorldToScreenPoint(Camera.main,braverObject.transform.position);
		
		BraverMaxHP = BraverHP;

		sliderHpGauge.maxValue = BraverMaxHP;
		SetHpUI();

		whiteJewels = 0;
		SetJewelText();

	}

	
	public void BraverDamage(int atk){
		BraverHP -= atk;
		SetDamageText(atk);
		if(BraverHP <= 0){
			BraverHP = 0;
			Death();
		}
		SetHpUI();
	}

	private void Death(){
		braverQuestManager.Death();
	}

	private void SetHpUI(){
		textHp.text = BraverHP + " / " + BraverMaxHP;
		sliderHpGauge.value = BraverHP;
	}
	public void SetDamageText(int value){
		var tmpText = Instantiate(TextBraverDamage);
		tmpText.transform.SetParent(CanvasUI.transform,false);
		tmpText.GetComponent<RectTransform>().position = braverPosRect;
		tmpText.GetComponent<TextMeshProUGUI>().text = "" + value;
		Destroy(tmpText,1.0f);
	}

	/*
	public void SetDamageText(int value,Vector3 targetPos){
		var tmpText = Instantiate(TextMonsterDamage);
		tmpText.transform.SetParent(CanvasUI.transform,false);
		tmpText.GetComponent<RectTransform>().position = RectTransformUtility.WorldToScreenPoint(Camera.main,targetPos);
		tmpText.GetComponent<TextMeshProUGUI>().text = "" + value;
		Destroy(tmpText,1.0f);
	}
	 */

	public void SetDamageText(int value,Vector3 targetPos){
		var tmpText = Instantiate(TextMonsterDamage,targetPos,Quaternion.identity);
		tmpText.GetComponentInChildren<TextMeshPro>().text = "" + value;
		Destroy(tmpText,1.0f);
	}


	public void AddJewel(int value){
		whiteJewels += value;
		SetJewelText();
	}

	private void SetJewelText(){
		textWhiteJewels.text = "" + whiteJewels;
	}

}
