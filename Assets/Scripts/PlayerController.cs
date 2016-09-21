using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Called before any physics calculations 
	private Rigidbody rb;
	public float speed;
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVeritcal = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVeritcal);

		rb.AddForce (movement * speed);
	}
}
