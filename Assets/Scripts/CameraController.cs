using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private Player player;
	private Vector3 destiny;
	private float z;
	private float y;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType (typeof(Player))as Player;
		transform.rotation = Quaternion.Euler (17.0f,0.0f,0.0f);
		z = -2.18f;
		y = 1.29f;
	}

	// Update is called once per frame
	void Update () {
		destiny = new Vector3 (transform.position.x, y, player.transform.position.z + z);

		transform.position = destiny;
	}
}
