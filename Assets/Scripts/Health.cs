using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
	public float startingHealth;
	public float currentHealth;
	private Slider healthSlider;
	private GameObject gameController;
	//public AudioClip deathClip;

	Animator anim;
//	AudioSource playerAudio;
	PlayerMovement playerMovement;
	//PlayerShooting playerShooting;
	bool isDead;

	void Awake ()
	{
		//playerAudio = GetComponent <AudioSource> ();
		//playerShooting = GetComponentInChildren <PlayerShooting> ();
		currentHealth = startingHealth;
		gameController = GameObject.Find ("GameController");
		healthSlider = GameObject.Find ("Slider").GetComponent <Slider> ();
	}

	public void TakeDamage (float amount)
	{
		Debug.Log ("Damage!" + transform.CompareTag ("Player"));
		currentHealth -= amount;
		if (isPlayer()) {
			Debug.Log ("Player hit!");
			healthSlider.value = currentHealth / startingHealth;
			anim.SetTrigger ("playerHit");
		}

		//playerAudio.Play ();

		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}

	bool isPlayer() {
		return transform.CompareTag ("Player");
	}

	bool isHuman() {
		return transform.CompareTag ("Human");
	}

	void Death ()
	{
		isDead = true;

		//playerShooting.DisableEffects ();

		//anim.SetTrigger ("Die");

		//		playerAudio.clip = deathClip;
		//		playerAudio.Play ();
		if (isPlayer ()) {
			playerMovement.enabled = false;
			//playerShooting.enabled = false;
		} else {
			if (isHuman ()) {
				gameController.GetComponent<GameController>().IncreaseDeadHumanCount ();
			}
			Destroy (gameObject);
		}
	}


	public void RestartLevel ()
	{
		SceneManager.LoadScene (0);
	}
}