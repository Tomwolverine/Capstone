using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	[SerializeField]int health;
	[SerializeField]int arrowDamage;
	[SerializeField]float moveSpeed;

	void TakeDamage(int damage) {
		health -= damage;
		if(health < 1) {
			Destroy(gameObject);
		}
    }	

	void OnTriggerEnter(Collider col) {
		var target = col.gameObject.name;
		if(target.Contains("Arrow")) {
			TakeDamage(arrowDamage);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
