using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMakerManager : MonoBehaviour {

	public float timeSpan = 0;
	private float time;

	public List<GameObject> slimeList = new List<GameObject>();

	public GameObject objectGeneratPosition;
	private Vector3 generatePosision;

	void Start () {
		time = timeSpan;
		generatePosision = objectGeneratPosition.transform.position;
	}
	

	void Update () {
		time -= Time.deltaTime;
		if(time <= 0){
			GenerateSlime();
		}
	}

	private void GenerateSlime(){
		var slime = Instantiate(slimeList[0],generatePosision,Quaternion.Euler(0,Random.Range(0,360),0));
		Vector3 force = new Vector3(Random.Range(-300,300),300,Random.Range(-500,-1000));
		slime.GetComponent<Rigidbody>().AddForce(force);
		time = timeSpan;
	}

}
