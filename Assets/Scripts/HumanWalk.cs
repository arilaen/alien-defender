using UnityEngine;
using System.Collections;
using System;
using System.IO;


public class HumanWalk : MonoBehaviour {
	public float moveTime = 0.1f;
	private Rigidbody rb;

	private float inverseMoveTime; 
	// Use this for initialization
	void Start () {
		inverseMoveTime = 1f / moveTime;
		rb = GetComponent<Rigidbody> ();
//		rb.velocity = new Vector3 (0f, 0.1f, 0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
//		Debug.Log (rb.position);
	}

//	bool move(int xDir, int yDir, int zDir){
//		//TODO: let's do dumb walking for now
//
//	}
}
	