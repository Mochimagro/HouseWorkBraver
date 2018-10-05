using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMakerManager : MonoBehaviour {

	public float timeSpan = 0;
	private float time;

	public int MaxSlimeLimite = 10;
	public List<GameObject> slimeList = new List<GameObject>();
	[SerializeField]private List<GameObject> aliveSlimeList = new List<GameObject>();

	public GameObject objectGeneratPosition;
	private Vector3 generatePosision;

	void Start () {
		time = timeSpan;
		generatePosision = objectGeneratPosition.transform.position;
		
	}
	

	void Update () {
		time -= Time.deltaTime;
		if(time <= 0){
			FreshList();
			if(aliveSlimeList.Count < MaxSlimeLimite){
				GenerateSlime();
			}
			
		}
	}

	private void FreshList(){
		int i = 0;
		while(i < aliveSlimeList.Count){
			if(aliveSlimeList[i] == null){
				aliveSlimeList.RemoveAt(i);
			}else{
				i++;
			}
		}
	}

	private void GenerateSlime(){
		var slime = Instantiate(slimeList[Random.Range(0,slimeList.Count - 1)],generatePosision,Quaternion.Euler(0,Random.Range(0,360),0));
		Vector3 force = new Vector3(Random.Range(-300,300),300,Random.Range(-500,-1000));
		slime.GetComponent<Rigidbody>().AddForce(force);
		aliveSlimeList.Add(slime);
		time = timeSpan;
	}

}
