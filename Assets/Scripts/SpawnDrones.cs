using UnityEngine;
using System.Collections;

public class SpawnDrones : MonoBehaviour {
	public GameObject drone;
	private GameObject gameController;
	public int numDrones = 10;

	void Awake() {
		gameController = GameObject.Find ("GameController");
	}

	void OnTriggerEnter (Collider col) {
		if (col.CompareTag("Player")) {
			Spawn ();
			gameController.GetComponent<GameController>().IncreaseDroneCount (numDrones);
			Destroy (gameObject);
		}
	}

	void Spawn ()
	{
		Vector3 spacing = Random.insideUnitSphere;
		Vector3 spawnPos = transform.position + spacing;
		spawnPos.y += 0.5f;
		for (int i = 0; i < numDrones; i++) {
			Instantiate (drone, transform.position + spacing, Quaternion.identity);
		}
	}
}
