using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(CharacterController))]
public class FPSController : MonoBehaviour {

        public float movementSpeed = 2f;
        public float mouseSensitivity = 2f;
        public float jumpSpeed = 2f;
        public int health = 100;
        public int maxHealth = 100;
        public int gold = 0;
        float verticalRotation = 0;

        public float upDownRange = 5.0f;
        float verticalVelocity = 0f;

        CharacterController player;



	// Use this for initialization
	void Start () {
        player = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Rotation
                float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
                transform.Rotate(0, rotLeftRight, 0);

                verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
                verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
                Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //Movement
                float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
                float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

                verticalVelocity += Physics.gravity.y * Time.deltaTime;
                if( player.isGrounded && Input.GetButton("Jump")) {
                        verticalVelocity = jumpSpeed;
                }

                Vector3 speed = new Vector3( sideSpeed, verticalVelocity, forwardSpeed);
                speed = transform.rotation * speed;

                player.Move(speed * Time.deltaTime);
        
	}

        void OnTriggerEnter(Collider col){
                var target = col.gameObject.name;
                if (target.Contains("Goblin")){
                        TakeDamage(25);

                }
                if (target.Contains("coins")){
                        Destroy(col.gameObject);
                        gold += 1;
                }
        }
        void TakeDamage(int damage) {
                health -= damage;
                if(health < 1) {
                        Debug.Log("gameover");
                }
        }
}
