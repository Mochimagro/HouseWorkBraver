using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraverQuestManager : MonoBehaviour {

	private Animator animator;
    private SphereCollider attackArea;

    private void Start() {
        animator = GetComponent<Animator>();
        animator.speed = 1.5f;
        animator.SetFloat("Speed",1);
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Monster")){
            
        }
    }

}
