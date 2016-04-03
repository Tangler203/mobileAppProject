using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public Text scoreText;
	public Text gameOverText;
	public int rockValue;

	private int score;

	// Use this for initialization
	void Start () {
		setScore ();
		UpdateScore ();
	}

	void OnTriggerEnter2D () {
		score += rockValue;
		UpdateScore ();
	}
	
	// Update is called once per frame
	void UpdateScore () {
		scoreText.text = "Score: " + getScore();
		gameOverText.text = "Game Over\nScore: " + getScore ();
	}

	public void setScore(){
		score = 0;
	}

	public int getScore(){
		return score;
	}
}
