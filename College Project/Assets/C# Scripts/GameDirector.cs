using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameDirector : MonoBehaviour {

	public Camera cam;
	public GameObject asteroid;
	private float maxWidth;
	public GameObject player;

	public GameObject gameOverText;
	public GameObject resetButton;
	public GameObject startButton;
	public GameObject scoreScript;
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
	}
	


	public void StartGame(){
		Instantiate (player, new Vector3 (0f, -1.57f, 0f), Quaternion.identity);
		Score s = scoreScript.GetComponent < Score > ();
		s.setScore ();
		startButton.SetActive (false);
		StartCoroutine (spawn ());
		while (GameObject.Find ("Player(Clone)") != null) {
			if (s.getScore() % 10 == 0 && s.getScore() != 0) {
				StartCoroutine (spawn ());
			}
		}
	}

	public void RestartGame()
	{
		SceneManager.LoadScene ("Main");
	}

	IEnumerator spawn(){
		yield return new WaitForSeconds (2f);
		while (GameObject.Find("Player(Clone)") != null) {
			Instantiate (asteroid, new Vector3 (Random.Range(-maxWidth,maxWidth), transform.position.y, 0), Quaternion.identity);
			yield return new WaitForSeconds (Random.Range(minwait,maxwait));
		}
		scoreText.SetActive (false);
		yield return new WaitForSeconds (2f);

		gameOverText.SetActive (true);
		resetButton.SetActive (true);
	}
		
}
