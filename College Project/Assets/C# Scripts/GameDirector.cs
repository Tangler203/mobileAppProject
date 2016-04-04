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
	public Text highScoreText;
	public GameObject highScoreTextGO;



	private float minwait = 1;
	private float maxwait = 2;
	public int drop;

	void Start () {
		
		if (cam == null) {
			cam = Camera.main;
		}

		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float ballWidth = asteroid.GetComponent<Renderer> ().bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;
		highScoreText.text ="High Score: "+PlayerPrefs.GetInt("highscore",0);
	}
	


	public void StartGame(){
		drop = 1;
		Instantiate (player, new Vector3 (0f, -1.57f, 0f), Quaternion.identity);
		Score s = scoreScript.GetComponent < Score > ();
		s.setScore ();
		startButton.SetActive (false);
		highScoreTextGO.SetActive (false);
		StartCoroutine (spawn ());
	}

	public void RestartGame()
	{
		SceneManager.LoadScene ("Main");
	}

	IEnumerator spawn(){
		yield return new WaitForSeconds (2f);
		while (GameObject.Find("Player(Clone)") != null) {
			for (int i = 0; i < drop; i++) {
				Instantiate (asteroid, new Vector3 (Random.Range (-maxWidth, maxWidth), Random.Range( transform.position.y-.5f,transform.position.y+.5f), 0), Quaternion.identity);
			}
			yield return new WaitForSeconds (Random.Range (minwait, maxwait));
		}
		scoreText.SetActive (false);
		Score s = scoreScript.GetComponent < Score > ();
		setHighscore (s.getScore());
		yield return new WaitForSeconds (2f);

		gameOverText.SetActive (true);
		resetButton.SetActive (true);
	}

	public void setWait(){
		minwait -= 0.25f;
		maxwait -= 0.5f;
	}

	public float getMinWait(){
		return minwait;
	}

	public void setDrop(){
		drop++;
	}

	void setHighscore(int newHighscore)
	{
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
		Debug.Log (newHighscore);
		if(newHighscore > oldHighscore)
			PlayerPrefs.SetInt("highscore", newHighscore);
		highScoreText.text= "High Score: "+PlayerPrefs.GetInt("highscore",0);
		PlayerPrefs.Save();
	}
}
