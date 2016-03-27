using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public float damage;
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
			targetNames.SetValue(targets [i].name, i);
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
		Debug.Log (col.gameObject.name);
		if (System.Array.IndexOf (targetNames, col.gameObject.name) > -1 ||
			System.Array.IndexOf (targetNames, col.gameObject.name.Replace("(Clone)", "")) > -1 &&
			timer >= timeBetweenAttacks && selfHealth.currentHealth > 0) {
			Debug.Log ("Taking damage!");
			col.GetComponent<Health>().TakeDamage(damage);
			timer = 0f;
			//AttackAudio.play();
		}
	}
}
