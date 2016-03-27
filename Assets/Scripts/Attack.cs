using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public int damage;
	public float timeBetweenAttacks;
	public float enemyAttackRange;
	public GameObject[] targets;
	private Health selfHealth;
	private float timer = 0f;
	private string[] targetNames;
	//attack audio

	void Awake () {
		selfHealth = GetComponent<Health> ();
		targetNames = new string[targets.Length];
		for (int i = 0; i < targets.Length; i++) {
			targetNames[i] = targets [i].name;
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	}

	bool targetInRange(Transform targetTransform) {
		return Vector3.Distance (targetTransform.position, transform.position) < enemyAttackRange;
	}

	void OnTriggerEnter(Collider col) {
		if (System.Array.IndexOf (targetNames, col.gameObject.name) > -1 && timer >= timeBetweenAttacks && selfHealth.currentHealth > 0) {
			col.GetComponent<Health>().TakeDamage(damage);
			timer = 0f;
			//AttackAudio.play();
		}
	}
}
