using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	public GUIText resultText;
	public GUIText gradeText;
	public GUIText highScoreText;
	public GUIText multText;
	public GUIText scoreText;
	public GUIText timeText;
	
	float clickCooldown = 1f;
	
	// Use this for initialization
	void Start () {
		Screen.lockCursor = false;
		
		int highScore = PlayerPrefs.GetInt("HighScore", 0);
		int score = PlayerPrefs.GetInt("Score");
		
		if(score > highScore) {
			highScore = score;
			PlayerPrefs.SetInt ("HighScore", highScore);
		}
		
		float time = PlayerPrefs.GetFloat("playTime");
		int minutes = (int)(time / 60);
		int seconds = (int)(time % 60);
			
		string timeString = minutes.ToString() + ":" + seconds.ToString();
		
		resultText.text = PlayerPrefs.GetInt("Victory") == 1 ? "Victory" : "Defeat";
		highScoreText.text = string.Format("{0:n0}", highScore);
		multText.text = PlayerPrefs.GetInt("highestMult").ToString();
		scoreText.text = string.Format("{0:n0}", score);
		timeText.text = timeString;

		if(score < 20000) {
			gradeText.text = "D";
		}
		else if (score < 40000) {
			gradeText.text = "C";
		}
		else if (score < 80000) {
			gradeText.text = "C+";
		}
		else if (score < 120000) {
			gradeText.text = "B";
		}
		else if (score < 160000) {
			gradeText.text = "B+";
		}
		else {
			string pluses = "";
			
			score -= 160000;
			while(score > 40000) {
				pluses = pluses + "+";
				score -= 40000;
			}
			
			gradeText.text = "A"+pluses;
		}
		
	}
	
	void Update() {
		clickCooldown -= Time.deltaTime;
		if(clickCooldown <= 0 && Input.GetMouseButtonDown(0)) {
			Screen.lockCursor = true;
			Application.LoadLevel("Level01");
		}
	}
	
}
