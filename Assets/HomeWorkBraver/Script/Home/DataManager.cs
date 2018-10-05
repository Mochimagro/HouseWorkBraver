using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DataName
{
	braverName,
	braverLevel,
	braverEXP,

}

public class DataManager : MonoBehaviour {

	//DEBUG用に
	[SerializeField]private int dataEXP = -1;
	[SerializeField]private int dataLevel = -1;
	[SerializeField]private string dataBraverName = "NONE_NAME";

	private const string KEY_BRAVER_LEVEL = "BraverLevel";
	private const string KEY_BRAVER_EXP = "BraverEXP";
	private const string KEY_BRAVER_NAME = "BraverName";

	private void Start() {
		DeleteAllData();
		DEBUG_ShowData();
	}

	public void DataSave(int value,DataName dataName){
		switch(dataName){
			case DataName.braverLevel:
				PlayerPrefs.SetInt(KEY_BRAVER_LEVEL,value);
				break;

			case DataName.braverEXP:
				PlayerPrefs.SetInt(KEY_BRAVER_EXP,value);
				break;
			
			default:
			break;
		}
		DEBUG_ShowData();
	}

	public void DataSave(string braverName){
		PlayerPrefs.SetString(KEY_BRAVER_NAME,braverName);
	
		DEBUG_ShowData();
	}

	public int LoadData(DataName dataName){
		switch(dataName){
			case DataName.braverLevel:
				return PlayerPrefs.GetInt(KEY_BRAVER_LEVEL,1);
				
			case DataName.braverEXP:
				return PlayerPrefs.GetInt(KEY_BRAVER_EXP,0);
			
			
			default:
			return -1;
			
		}
	}

	public void DeleteAllData(){
		PlayerPrefs.DeleteAll();
		DEBUG_ShowData();
	}

	private void DEBUG_ShowData(){
		dataLevel = PlayerPrefs.GetInt(KEY_BRAVER_LEVEL);
		dataEXP = PlayerPrefs.GetInt(KEY_BRAVER_EXP);
		dataBraverName = PlayerPrefs.GetString(KEY_BRAVER_NAME);
	}

}
