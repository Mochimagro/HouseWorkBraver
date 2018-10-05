using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelMakerManager : MonoBehaviour {

	public List<GameObject> jewelList = new List<GameObject>();

	public float maxX,maxY,maxZ;
	private QuestManager questManager;

	private void Start() {
		questManager = GetComponent<QuestManager>();
	}

	public void MakeJewels(int value,Vector3 pos){
		StartCoroutine(IE_MakeJewels(value,pos));
	}

	IEnumerator IE_MakeJewels(int value,Vector3 pos){
		for(var i = 0;i < value;i++){
			var tmp = Instantiate(jewelList[0],pos,Quaternion.identity);
			Vector3 forceVecter = new Vector3(Random.Range(-maxX,maxX),Random.Range(-maxY,maxY),Random.Range(-maxZ,maxZ));
			tmp.GetComponent<Rigidbody>().AddForce(forceVecter);
			tmp.GetComponent<JewelManager>().SetQuestManager(questManager);

			yield return new WaitForSeconds(0.03f);
		}
	}

	public void DebugMakeJewels(int value){
		MakeJewels(value,transform.position);
	}

}
