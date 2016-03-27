﻿using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class HumanWalk : MonoBehaviour {
	private GameObject gameController;
	public float movementSpeed = 0.5f;

	private float timer = 1.5f;
	private float timeToTurn;
	private Rigidbody humanRigidBody;

	void Awake() {
		setTimeToTurn ();
		humanRigidBody = GetComponent<Rigidbody> ();
		gameController = GameObject.Find ("GameController");
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	}

	void FixedUpdate() {
		transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
		if (Math.Abs(transform.position.x) >= 7 || Math.Abs(transform.position.z) >= 7) {
			timer = 0f;
			setTimeToTurn ();
			humanRigidBody.MoveRotation (Quaternion.LookRotation(-1f * transform.position));
		} else if (timer > timeToTurn) {
			timer = 0f;
			setTimeToTurn ();
			humanRigidBody.MoveRotation (Quaternion.Euler( 0, UnityEngine.Random.Range(0, 360), 0));
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.CompareTag ("Player")) {
			Destroy (gameObject);
			gameController.GetComponent<GameController>().IncreaseSavedHumanCount ();
		}
	}

	void setTimeToTurn() {
		timeToTurn = UnityEngine.Random.Range (2f, 5f);
	}
}
	