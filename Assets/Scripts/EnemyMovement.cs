using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	GameObject player;
	Health playerHealth;
	Health enemyHealth;
	NavMeshAgent nav;


	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.transform.GetComponent <Health> ();
		enemyHealth = GetComponent <Health> ();
		nav = GetComponent <NavMeshAgent> ();
	}


	void Update ()
	{
		if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		{
			nav.SetDestination (GetClosestTarget().position);
		}
		else
		{
			nav.enabled = false;
		}
	}

	Transform GetClosestTarget () //http://forum.unity3d.com/threads/clean-est-way-to-find-nearest-object-of-many-c.44315/
	{
		GameObject[] humans = GameObject.FindGameObjectsWithTag("Human");
		GameObject[] targets = new GameObject[humans.Length + 1];
		humans.CopyTo(targets, 0);
		targets.SetValue(player, targets.Length - 1);
		Transform bestTarget = null;
		float closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = transform.position;
		foreach(GameObject potentialTarget in targets)
		{
			Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
			float dSqrToTarget = directionToTarget.sqrMagnitude;
			if(dSqrToTarget < closestDistanceSqr)
			{
				closestDistanceSqr = dSqrToTarget;
				bestTarget = potentialTarget.transform;
			}
		}

		return bestTarget;
	}
}
