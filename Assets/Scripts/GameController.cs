using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int droneCount = 0;

	public void IncreaseDroneCount (int numDrones) {
		droneCount += numDrones;
	}
}