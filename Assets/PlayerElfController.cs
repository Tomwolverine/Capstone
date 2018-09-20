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
	void Start ()
    {
        state = State.Idle;
        damageHurt = GetComponent<DamageHurt>();
        Cursor.lockState = CursorLockMode.Locked;
	}

    // Update is called once per frame
    void Update()
    {
       // float translation = Input.GetAxis("Vertical") * speed;
       // float straffe = Input.GetAxis("Horizontal") * speed;
       // translation *= Time.deltaTime;
       // straffe *= Time.deltaTime;

       // transform.Translate(straffe, 0, translation);

      //  if (Input.GetKeyDown("escape")){
        //    Cursor.lockState = CursorLockMode.None;
       // }
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
