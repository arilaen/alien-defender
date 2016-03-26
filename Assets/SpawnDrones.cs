using UnityEngine;
using System.Collections;

public class SpawnDrones : MonoBehaviour {
	public GameObject drone;
	public Transform[] spawnPoints;

	void onTriggerEnter (Collider col) {
		Debug.Log ("Trigger!");
		if (col.CompareTag("Player")) {
			Spawn ();
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
