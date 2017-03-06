using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Vector3 movement;
	Rigidbody playerRigibody;
	// Use this for initialization
	void Start () {
		playerRigibody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		float h = Input.GetAxisRaw ("Horizontal");
		Move (h);

		float moveZ = transform.position.z + 1f;


		transform.position = new Vector3 (transform.position.x , transform.position.y , moveZ);
	}

	void Move(float h){
		movement.Set (h, 0f, 0f);
		movement = movement.normalized * 3.0f * Time.deltaTime;
		playerRigibody.MovePosition (transform.position + movement);
	}
}
