using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateSavedHumans : MonoBehaviour {

	Text txt;

	public GameObject gameController;

	void Start () {
		txt = gameObject.GetComponent<Text>();
	}

	void Update () {
		txt.text = "x " + gameController.GetComponent<GameController>().savedHumanCount;
	}
}
