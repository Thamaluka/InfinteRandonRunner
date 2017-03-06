using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour {
	//public variables
	public GameObject Straight , Right , Left;

	//private variables
	private GameObject Temp , Spawn;
	private int Destiny ;
	private Vector3 TempScale = new Vector3 ();
	private float yRight, yLeft, yStraight;

	// Use this for initialization
	void Start () {
		//initializing variable
		yRight = 0.0f;
		yLeft = 0.0f;
		yStraight = 0.0f;

		//Resetting transforms
		Right.transform.rotation = Quaternion.Euler (0.0f,0.0f,0.0f);
		Left.transform.rotation = Quaternion.Euler (0.0f,0.0f,0.0f);
		Straight.transform.rotation = Quaternion.Euler (0.0f,0.0f,0.0f);

		yRight =Right.transform.rotation.y;
		yLeft = Left.transform.rotation.y;
		yStraight =Straight.transform.rotation.y;

		//Spawning straights
		for (int i = 0; i < 8; i++) {
			Instantiate (Straight, TempScale, Straight.transform.rotation);
			TempScale.z += Straight.GetComponent<BoxCollider> ().size.z;
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		randomBlock ();

			//Spawning straights and set direction
			for (int i = 0; i <15; i++) {
			Instantiate (Straight, TempScale, Straight.transform.rotation);

				if (yStraight == 0.0f) {
					TempScale.z += Straight.GetComponent<BoxCollider> ().size.z;
				}

				if (yStraight == -90.0f) {
					TempScale.x -= Straight.GetComponent<BoxCollider> ().size.z;
				}
		
				if (yStraight == 90.0f) {
					TempScale.x +=	Straight.GetComponent<BoxCollider> ().size.z;

				}
				if (yStraight == 180.0f || yStraight == 180) {
				TempScale.z -= Straight.GetComponent<BoxCollider> ().size.z;
				}
			}

		//Destroy objects in the scene
		GameObject[] itens = GameObject.FindGameObjectsWithTag ("Itens");
		for (int i = 0; i < itens.Length; i++) {
			Destroy (itens [i], 0.5f);
		}
			
	
	}



	void randomBlock(){
		Destiny = Random.Range (0,2);
		spawnBlocks ();
	}

	//Which block will be spawned
	void spawnBlocks(){
		switch (Destiny){
		case 0:
			Spawn = Left;
			leftTripe ();
			break;
		case 1:
			Spawn = Right;
			rightTripe ();
			break;
		}
	}

	//Change the straight rotation when the object is right corner
	void rightTripe(){
		
		fixCorners();
		TempScale.z += 1.0f; 
		Instantiate (Right, TempScale, Right.transform.rotation);

		if (yRight == 0.0f) {
			yStraight = 90.0f;
			TempScale.x += Right.GetComponent<BoxCollider> ().size.x;

		}

		if (yRight == 90.0f) {
			yStraight = 180.0f;
			TempScale.z -= (Right.GetComponent<BoxCollider> ().size.y);
		}

		if (yRight == 180.0f) {
			yStraight = -90.0f;
			TempScale.x -= Right.GetComponent<BoxCollider> ().size.x;

		} 

		if (yRight == -90.0f) {
			yStraight = 0.0f;
			TempScale.z += (Right.GetComponent<BoxCollider> ().size.y);

		}


		yRight = yStraight;
		yLeft = yStraight;


		//new rotation
		Straight.transform.rotation = Quaternion.Euler (0.0f,yStraight,0.0f);
		Right.transform.rotation = Quaternion.Euler (0.0f,yRight,0.0f);
		Left.transform.rotation = Quaternion.Euler (0.0f,yLeft,0.0f);
	

	}

	//Change the straight rotation when the object is left corner
	void leftTripe(){
		
		fixCorners();
		TempScale.z += 1.0f;  
		Instantiate (Left, TempScale, Left.transform.rotation);

		if (yLeft == 0.0f) {
			yStraight = -90.0f;
			TempScale.x -= Left.GetComponent<BoxCollider> ().size.x;
			TempScale.z += Spawn.transform.position.z;
		}

		if (yLeft == -90.0f) {
			yStraight = 180.0f;
			TempScale.z -= (Left.GetComponent<BoxCollider> ().size.x);
		}

		if (yLeft == 180.0f) {
			yStraight = 90.0f;
			TempScale.x += Left.GetComponent<BoxCollider> ().size.x;
		} 

		if (yLeft == 90.0f) {
			yStraight = 0.0f;
			TempScale.z += (Left.GetComponent<BoxCollider> ().size.y);
		}


		yLeft = yStraight;
		yRight = yStraight;

		// new rotation
		Straight.transform.rotation = Quaternion.Euler (0.0f, yStraight, 0.0f);
		Right.transform.rotation = Quaternion.Euler (0.0f, yRight, 0.0f);
		Left.transform.rotation = Quaternion.Euler (0.0f, yLeft, 0.0f);
		
	}

	//Fiz the corners when the square change the sides
	void fixCorners(){
		if (yRight == 90.0f || yLeft == 90.0f  ) {
			TempScale.x += 1.0f;
			TempScale.z -= 1.0f;
		}

		if( yRight == 180.0f || yLeft == 180.0f){
			TempScale.z -= 2.0f;
		}

		if(yRight == -90.0f || yLeft == -90.0f){
			TempScale.z -= 1.0f;
			TempScale.x -= 1.0f;
		}


	}
		
}

