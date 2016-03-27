using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] spawnees;
	public Transform[] spawnPoints;
	public float spawnDelay = 2f;
	public float spawnRate = 4f;
	public float timeLimit = 16f;

	void Start () {
		StartCoroutine ("SpawnRoutine");
	}

	IEnumerator SpawnRoutine() {
		while (Time.realtimeSinceStartup < spawnDelay) {
			yield return null;
		}
		while (Time.realtimeSinceStartup < timeLimit) {
			Spawn ();
			yield return new WaitForSeconds (spawnRate);
		}
		yield return null;
	}

	void Spawn ()
	{
		GameObject spawnee = spawnees [Random.Range (0, spawnees.Length - 1)];
		for (int i = 0; i < spawnPoints.Length; i++) {
			Instantiate (spawnee, spawnPoints[i].position, spawnPoints[i].rotation);
		}
	}

}
