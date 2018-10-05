using TMPro;
using UnityEngine;


public class LevelUpAnimation : MonoBehaviour{

    public void OnAnimationEnd(){
        gameObject.SetActive(false);
    }

}