using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraverQuestManager : MonoBehaviour {

	private Animator animator;
    private SphereCollider attackArea;
    private Vector3 pos;

    private void Start() {
        animator = GetComponent<Animator>();
        animator.speed = 1.5f;
        animator.SetFloat("Speed",1);
        pos = transform.position;
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Monster")){
            animator.SetTrigger("Attack");
        }
    }

    private void Hit(){

    }

    private void HittingAttack(){

    }

    private void FinishAttack(){
        transform.position = pos;
    }

}
