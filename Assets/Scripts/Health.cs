using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
	public int startingHealth;
	public int currentHealth;
	public Slider healthSlider;
	//public AudioClip deathClip;

//	Animator anim;
//	AudioSource playerAudio;
	//PlayerMovement playerMovement;
	//PlayerShooting playerShooting;
	bool isDead;

	void Awake ()
	{
		//anim = GetComponent <Animator> ();
		//playerAudio = GetComponent <AudioSource> ();
//		if (isPlayer()) {
//			playerMovement = GetComponent <PlayerMovement> ();
//		}
		//playerShooting = GetComponentInChildren <PlayerShooting> ();
		currentHealth = startingHealth;
	}

	public void TakeDamage (int amount)
	{
		currentHealth -= amount;
		if (isPlayer()) {
			healthSlider.value = currentHealth;
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


	void Death ()
	{
		isDead = true;

		//playerShooting.DisableEffects ();

		//anim.SetTrigger ("Die");

		//		playerAudio.clip = deathClip;
		//		playerAudio.Play ();

//		playerMovement.enabled = false;
		//playerShooting.enabled = false;
	}


	public void RestartLevel ()
	{
		SceneManager.LoadScene (0);
	}
}