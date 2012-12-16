using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	public GUISkin skin;
	
	int score = 0;
	int mult = 1;
	
	int highestMult = 1;
	
	float playTime = 0;
	
	float multTimerMax = 2f;
	float multTimer = 0;
	float multTimerWidth = 225;
	public GameObject multTimerText;
	
	static Score instance;

	// Use this for initialization
	void Start () {
		if(instance == null) {
			instance = this;
		}
	}
	
	void OnDestroy() {
		PlayerPrefs.SetInt("Score", score);
		PlayerPrefs.SetInt("highestMult", highestMult);
		PlayerPrefs.SetFloat("playTime", playTime);
	}
	
	// Update is called once per frame
	void Update () {
		playTime += Time.deltaTime;
		
		if(multTimer > 0) {
			multTimer -= Time.deltaTime;
			
			Rect r = multTimerText.guiTexture.pixelInset;
			r.width = Mathf.Max ( multTimer / multTimerMax * multTimerWidth, 0);
			multTimerText.guiTexture.pixelInset = r;
			
			if(multTimer <= 0) {
				mult = 1;
			}
		}
	}
	
	void OnGUI() {
		GUI.skin = skin;
		GUI.Label( new Rect(10, Screen.height - 55, 165, 50), string.Format("{0:n0}", score) );
		GUI.Label( new Rect(165, Screen.height - 55, 100, 50), "x"+mult );
	}
	
	public static void AddPoints(int v) {
		instance.score += v * instance.mult;
	}
	
	public static void AddMult() {
		instance.mult += 1;
		instance.multTimer = instance.multTimerMax;
		
		if(instance.mult > instance.highestMult) {
			instance.highestMult = instance.mult;
		}
	}
}
