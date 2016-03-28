using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public float damage;
	public float timeBetweenAttacks;
	public float enemyAttackRange;
	public GameObject[] targets;
	public AudioClip attackClip;
	private Health selfHealth;
	private float timer = 0f;
	private string[] targetNames;
	AudioSource audioSource;

	void Awake () {
		audioSource = GetComponent<AudioSource> ();
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
		if (System.Array.IndexOf (targetNames, col.gameObject.name) > -1 ||
			System.Array.IndexOf (targetNames, col.gameObject.name.Replace("(Clone)", "")) > -1 &&
			timer >= timeBetweenAttacks && selfHealth.currentHealth > 0) {
			Health targetHealth = col.GetComponent<Health> ();
			if (targetHealth.currentHealth > 0) {
				targetHealth.TakeDamage (damage);
				timer = 0f;
				audioSource.PlayOneShot (attackClip);
			}
		}
	}
}
