using UnityEngine;
using System.Collections;

public class SpawnDrones : MonoBehaviour {
	public GameObject drone;
	public Transform[] spawnPoints;
	public GameObject gameController;

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.name == "Player") {
			Spawn ();
			gameController.GetComponent<GameController>().IncreaseDroneCount (spawnPoints.Length);
			Destroy (gameObject);
		}
	}

	void Spawn ()
	{
		for (int i = 0; i < spawnPoints.Length; i++) {
			Instantiate (drone, spawnPoints[i].position, spawnPoints[i].rotation);
		}
	}
}
