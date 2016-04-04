using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public Text scoreText;
	public Text gameOverText;
	public int rockValue;
	public GameObject waittime;
	public GameDirector gd;

	private int score;


	// Use this for initialization
	void Start () {
		setScore ();
		UpdateScore ();
		gd = waittime.GetComponent <GameDirector> ();
	}

	void OnTriggerEnter2D () {
		score += rockValue;
		UpdateScore ();

		if (score%10 == 0 && gd.getMinWait() > .25){
			gd.setWait();
			if (score % 15 == 0) {
				gd.setDrop();
			}
		}

	}

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
