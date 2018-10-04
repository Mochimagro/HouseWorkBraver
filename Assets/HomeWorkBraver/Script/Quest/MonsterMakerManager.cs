using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMakerManager : MonoBehaviour {

	public List<GameObject> MonsterList = new List<GameObject>();

	public float summonInterval = 3f;
	private float interval;
	
	public GameObject objectSummonPosition;
	private Vector3 summonPosition;



	private void Start() {
		summonPosition = objectSummonPosition.transform.position;
		interval = summonInterval;
	}

	private void Update() {
		interval -= Time.deltaTime;

		if(interval <= 0){
			MonsterSummon();
			interval = summonInterval;
		}
	}

	public void MonsterSummon(){
		Instantiate(MonsterList[0],summonPosition,MonsterList[0].transform.rotation);
	}


}
