using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraverQuestManager : MonoBehaviour {

    public int hp = 50;
    public int atk = 3;
    public float speed = 1.5f;
    public float intervalTime = 5.0f;
    public GameObject Weapon;

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
        
    }

    private void Update() {
        if(interval > 0){
            interval -= Time.deltaTime;
        }
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
            Death();
        }
    }

    private void Death(){
        animator.SetTrigger("Death");
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
