using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameDirector : MonoBehaviour {

	public Camera cam;
	public GameObject asteroid;
	private float maxWidth;
	public GameObject gameOverText;
	public GameObject scoreText;

	private float minwait = 1;
	private float maxwait = 2;

	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float ballWidth = asteroid.GetComponent<Renderer> ().bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;
		StartCoroutine (spawn ());
	
	}
	
	void FixedUpdate(){
	
	}

	IEnumerator spawn(){
		yield return new WaitForSeconds (2f);
		while (GameObject.Find("Player") != null) {
			Instantiate (asteroid, new Vector3 (Random.Range(-maxWidth,maxWidth), transform.position.y, 0), Quaternion.identity);
			yield return new WaitForSeconds (Random.Range(minwait,maxwait));
		}
		scoreText.SetActive (false);
		yield return new WaitForSeconds (2f);

		gameOverText.SetActive (true);
	}
}
