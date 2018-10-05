using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelManager : MonoBehaviour {

    public int price;
    [SerializeField]private QuestManager questManager;

    private void Start() {
        StartCoroutine(DeleteThisJewel());
    }

    public void SetQuestManager(QuestManager quest){
        questManager =  quest;
    }
	
    IEnumerator DeleteThisJewel()
    {
        yield return new WaitForSeconds(1.5f);
        questManager.AddJewel(price);
        Destroy(gameObject);
    }

}
