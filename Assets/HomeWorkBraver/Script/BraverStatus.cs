using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]public class BraverStatusClass{
	public string braverName = "Braver";
	public int[,] HpAtkList;

}

public class BraverStatus : MonoBehaviour {
	public List<BraverStatus> StatusList = new List<BraverStatus>();
}
