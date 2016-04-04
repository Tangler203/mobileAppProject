using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb2d;
	private Vector2 touchOrigen = -Vector2.one;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}
	void Update(){
		if (Application.platform == RuntimePlatform.WSAPlayerX64) {
			
			foreach (Touch touch in Input.touches) {
				Vector2 playertouch = touch.position;
				if (touch.position.x < Screen.width / 2) {
					rb2d.AddForce (Vector2.left * speed);
				} else {
					rb2d.AddForce (Vector2.left * speed);
				}
			}
		}
	}

	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (moveHorizontal, 0);

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		rb2d.AddForce (movement * speed);
	}
}
