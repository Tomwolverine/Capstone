using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(CharacterController))]
public class FPSController : MonoBehaviour {

        public float movementSpeed = 2f;
        public float mouseSensitivity = 2f;
        public float jumpSpeed = 2f;

        float verticalRotation = 0;

        public float upDownRange = 0.0f;
        float verticalVelocity = 0f;

        CharacterController player;

        //public GameObject eyes;

        // float moveFB;
        // float moveLR;

        // float rotx;
        // float roty;

	// Use this for initialization
	void Start () {
        player = GetComponent<CharacterController>();
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
        // moveFB = Input.GetAxis("Vertical") * speed;
        // moveLR = Input.GetAxis("Horizontal") * speed;

        //rotx = Input.GetAxis("Mouse X") * sensitivity;
        //roty = Input.GetAxis("Mouse Y") * sensitivity;

        //Vector3 movement = new Vector3(moveLR, 0, moveFB);
        //transform.Rotate(0, rotx, 0);
        //eyes.transform.Rotate(-roty, 0, 0);

        //movement = transform.rotation * movement;
        //player.Move(movement * Time.deltaTime);
	}
}
