using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawnee;
	public Transform[] spawnPoints;
	public float spawnDelay = 2f;
	public float spawnRate = 5f;
	public float timeLimit = 16f;
	
	// Update is called once per frame
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
		for (int i = 0; i < spawnPoints.Length; i++) {
			Instantiate (spawnee, spawnPoints[i].position, spawnPoints[i].rotation);
		}
	}

}
