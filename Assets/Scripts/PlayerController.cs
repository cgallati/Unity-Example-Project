using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Called before any physics calculations 
	private Rigidbody rb;
	public float speed;
	private int count;
	public Text countText;
	public Text winText;
	public Camera thirdPerson;
	public Camera overhead;

	void Start ()
	{
		thirdPerson.enabled = true;
		overhead.enabled = false;

		rb = GetComponent<Rigidbody> ();
		count = 0;
		setCountText ();
		winText.text = "";
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVeritcal = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVeritcal);

		rb.AddForce (movement * speed);
	}

	void Update() {

		if (Input.GetKeyDown(KeyCode.C)) {
			thirdPerson.enabled = !thirdPerson.enabled;
			overhead.enabled = !overhead.enabled;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			setCountText ();
		}
	}

	void setCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You win!";
		}
	}
}