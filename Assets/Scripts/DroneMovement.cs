using UnityEngine;
using System.Collections;

public class DroneMovement : MonoBehaviour
{
	Health selfHealth;
	NavMeshAgent nav;
	Transform closestTarget;

	void Awake ()
	{
		selfHealth = GetComponent <Health> ();
		nav = GetComponent <NavMeshAgent> ();
	}


	void Update ()
	{
		if (selfHealth.currentHealth > 0) {
			closestTarget = GetClosestEnemy ();
			if (closestTarget) {
				nav.SetDestination (closestTarget.position);
			}
		}
		else
		{
			nav.enabled = false;
		}
	}

	Transform GetClosestEnemy () //http://forum.unity3d.com/threads/clean-est-way-to-find-nearest-object-of-many-c.44315/
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		Transform bestTarget = null;
		float closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = transform.position;
		foreach(GameObject potentialTarget in enemies)
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
