using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	Transform player;
	Health playerHealth;
	Health enemyHealth;
	NavMeshAgent nav;


	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = player.GetComponent <Health> ();
		enemyHealth = GetComponent <Health> ();
		nav = GetComponent <NavMeshAgent> ();
	}


	void Update ()
	{
		if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		{
			nav.SetDestination (player.position);
		}
		else
		{
			nav.enabled = false;
		}
	}
}
