using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostNpcController : MonoBehaviour {
    [SerializeField] int health;
    [SerializeField] float speed;
    [SerializeField] int damage;
    enum State
    {
        Idle,
        Moving,
        Attacking,
        Hurt,
        Death
    }
    [SerializeField] State state;

    // Use this for initialization
    void Start () {
        state = State.Idle;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
