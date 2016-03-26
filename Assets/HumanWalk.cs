using UnityEngine;
using System.Collections;
using System;
using System.IO;


public class HumanWalk : MonoBehaviour {
	public float moveTime = 0.1f;
	private BoxCollider2D boxCollider;
	private float inverseMoveTime; 

	// Use this for initialization
	void Start () {
		boxCollider = GetComponent <BoxCollider2D> ();
		inverseMoveTime = 1f / moveTime;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Whatever");
	}

//	bool move(int xDir, int yDir, int zDir){
//		//TODO: let's do dumb walking for now
//
//	}
}
