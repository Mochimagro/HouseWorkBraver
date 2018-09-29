using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BraverQuestManager : MonoBehaviour {

    public int hp = 50;
    private int maxHp;
    public int atk = 3;
    public float speed = 1.5f;
    public float intervalTime = 5.0f;
    public GameObject Weapon;
    public Slider SliderHpGauge;
    public TextMeshProUGUI TextHp;
    
    public GameObject SliderIntervalGuage;
    private Slider intervalSlider;

	private Animator animator;
    private SphereCollider attackArea;
    private BoxCollider weaponCollider;
    private Vector3 pos;
    private float interval = 0;
    private GameObject target;

    private void Start() {
        animator = GetComponent<Animator>();
        weaponCollider = Weapon.GetComponent<BoxCollider>();
        animator.speed = speed;
        animator.SetFloat("Speed",1);
        pos = transform.position;
        maxHp = hp;
        SliderHpGauge.maxValue = maxHp;
        intervalSlider = SliderIntervalGuage.GetComponent<Slider>();
        intervalSlider.maxValue = intervalTime;
        SetHpUI();
    }

    private void Update() {
        SetIntervalSlider();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Monster")){
            if(interval <= 0){
                animator.SetTrigger("Attack");
                interval = intervalTime;
            }
        }
    }

    public void Damage(int atk){
        hp -= atk;
        if(hp <= 0){
            hp = 0;
            Death();
        }
        SetHpUI();
    }

    private void Death(){
        animator.SetTrigger("Death");
    }

    public void SetHpUI(){
        TextHp.text = hp + " / " + maxHp;
        SliderHpGauge.value = hp;
    }

    private void SetIntervalSlider(){
        
        if(interval > 0){
            if(!SliderIntervalGuage.activeSelf){
                SliderIntervalGuage.SetActive(true);
            }
            interval -= Time.deltaTime;
            intervalSlider.value = interval;
            if(interval <= 0){
                SliderIntervalGuage.SetActive(false);
            }
        }
        
    }

    //アニメーション用

    private void Hit(){
    }

    private void HittingAttack(){
        weaponCollider.enabled = true;
    }

    private void FinishAttack(){
        transform.position = pos;
        weaponCollider.enabled = false;
    }

}
