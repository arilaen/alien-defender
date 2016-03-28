using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
	public float startingHealth;
	public float currentHealth;
	private Slider healthSlider;
	private GameObject gameController;
	public AudioClip hitClip;
	public AudioClip deathClip;
	AudioSource audioSource;

	Animator anim;
	PlayerMovement playerMovement;
	//PlayerShooting playerShooting;
	bool isDead;

	void Awake ()
	{
		audioSource = GetComponent <AudioSource> ();
		//playerShooting = GetComponentInChildren <PlayerShooting> ();
		if (isPlayer()) {
			anim = GameObject.Find("PlayerSprite").GetComponent<Animator> ();
			playerMovement = gameObject.GetComponent<PlayerMovement> ();
		}
		currentHealth = startingHealth;
		gameController = GameObject.Find ("GameController");
		healthSlider = GameObject.Find ("Slider").GetComponent <Slider> ();
	}

	public void TakeDamage (float amount)
	{
		if (!isDead) {
			currentHealth -= amount;
			if (isPlayer ()) {
				healthSlider.value = currentHealth / startingHealth;
				anim.SetTrigger ("playerHit");
			}
			if (hitClip) {
				audioSource.PlayOneShot (hitClip);
			}

			if (currentHealth <= 0) {
				Death ();
			}
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
		if (deathClip) {
			audioSource.PlayOneShot (deathClip);
		}
		//playerShooting.DisableEffects ();

		//anim.SetTrigger ("Die");

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