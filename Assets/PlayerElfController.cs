using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElfController : MonoBehaviour {
    [SerializeField] int maxHealth = 100;
    [SerializeField]int health;
    [SerializeField]float speed;
    [SerializeField]int damage;
    enum State
    {
        Idle, 
        Moving,
        Attacking,
        Hurt,
        Death
    }
    [SerializeField]State state;
    DamageHurt damageHurt;
	// Use this for initialization
	void Start () {
        state = State.Idle;
        damageHurt = GetComponent<DamageHurt>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            state = State.Hurt;
            health-= (damageHurt.takeDamage(10));
        }
        else if (Input.GetKey(KeyCode.UpArrow))
            state = State.Moving;
        else if (Input.GetKey(KeyCode.DownArrow))
            state = State.Moving;
        else if (Input.GetKey(KeyCode.RightArrow))
            state = State.Moving;
        else if (Input.GetKey(KeyCode.LeftArrow))
            state = State.Moving;
        else if (Input.GetKey(KeyCode.B))
            state = State.Attacking;
        
	}
}
