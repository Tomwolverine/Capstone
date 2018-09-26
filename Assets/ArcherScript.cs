using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherScript : MonoBehaviour {
	Animator animator;
	[SerializeField]int health;
	[SerializeField]int arrowDamage;
	[SerializeField]float moveSpeed;

	void Start(){
		animator = GetComponent<Animator>();
	}
	void TakeDamage(int damage) {
		health -= damage;
		if(health < 1) {
			animator.SetTrigger("death"); 
			StartCoroutine(destroySelf());

		}
    }	

	void OnTriggerEnter(Collider col) {
		var target = col.gameObject.name;
		if(target.Contains("Arrow")) {
			TakeDamage(arrowDamage);
		}
		if(target.Contains("Player")){
			animator.SetBool("attack", true);
			StartCoroutine(idle());
		}
	}
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator destroySelf(){
		yield return new WaitForSeconds(8f); 
		Destroy(gameObject);
	}

	IEnumerator idle(){
		yield return new WaitForSeconds(2f); 
		animator.SetBool("attack", false);
	}
}
