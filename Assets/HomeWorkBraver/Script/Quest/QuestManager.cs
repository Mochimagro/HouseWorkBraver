using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour {

	public GameObject Monster;

	public GameObject objectSummonPosition;
	public GameObject TextBraverDamage;
	public GameObject TextMonsterDamage;
	public Canvas CanvasUI;
	private Vector3 summonPosition;
	private Vector3 braverPosRect;

	private void Start() {
		summonPosition = objectSummonPosition.transform.position;
	
		braverPosRect = RectTransformUtility.WorldToScreenPoint(Camera.main,GameObject.FindGameObjectWithTag("Braver").transform.position);

	}

	public void MonsterSummon(){
		Instantiate(Monster,summonPosition,Monster.transform.rotation);
	}

	public void SetDamageText(int value){
		var tmpText = Instantiate(TextBraverDamage);
		tmpText.transform.SetParent(CanvasUI.transform,false);
		tmpText.GetComponent<RectTransform>().position = braverPosRect;
		tmpText.GetComponent<TextMeshProUGUI>().text = "" + value;
		Destroy(tmpText,1.0f);
	}

	public void SetDamageText(int value,Vector3 pos){
		var tmpText = Instantiate(TextMonsterDamage);
		tmpText.transform.SetParent(CanvasUI.transform,false);
		tmpText.GetComponent<RectTransform>().position = RectTransformUtility.WorldToScreenPoint(Camera.main,pos);
		tmpText.GetComponent<TextMeshProUGUI>().text = "" + value;
		Destroy(tmpText,1.0f);

	}

}
