using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public GameObject Monster;

	public GameObject objectSummonPosition;
	private Vector3 summonPosition;

	private void Start() {
		summonPosition = objectSummonPosition.transform.position;
	}

	public void MonsterSummon(){
		Instantiate(Monster,summonPosition,Monster.transform.rotation);
	}

}
