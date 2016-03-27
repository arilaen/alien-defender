using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int droneCount = 0;
	public int savedHumanCount = 0;
	public int deadHumanCount = 0;

	public void IncreaseDroneCount (int numDrones) {
		droneCount += numDrones;
	}
	public void IncreaseDeadHumanCount () {
		deadHumanCount ++;
	}
	public void IncreaseSavedHumanCount () {
		savedHumanCount ++;
	}
}