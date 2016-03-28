using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;

	private Vector3 movement;
	private Animator anim;
	private Rigidbody playerRigidbody;
	private int groundMask;
	private float camRayLength = 100f;

	void Awake()
	{
		groundMask = LayerMask.GetMask ("Ground");
		anim = GameObject.Find("PlayerSprite").GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		Turning ();
	}
	void Move(Vector3 movement)
	{
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement);
	}
	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast (camRay, out floorHit, camRayLength, groundMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidbody.MoveRotation (newRotation);
			if (Input.GetMouseButton (0)) { //Move
				Move (floorHit.point);
				anim.SetBool ("playerWalking", true);
			} else {
				anim.SetBool ("playerWalking", false);
			}
		}
	}
}
