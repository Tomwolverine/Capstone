using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Shooting : MonoBehaviour {

    public GameObject arrow_prefab;
    float arrowImpulse = 18f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            Camera cam = Camera.main;
            GameObject thearrow = (GameObject)Instantiate(arrow_prefab, transform.position, transform.rotation);
            thearrow.GetComponent<Rigidbody>().AddForce(cam.transform.forward * arrowImpulse, ForceMode.Impulse);
        }
	}
}
