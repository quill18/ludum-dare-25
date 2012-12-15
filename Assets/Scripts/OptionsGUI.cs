using UnityEngine;
using System.Collections;

public class OptionsGUI : MonoBehaviour {
	
	bool paused = false;
	bool soundEnabled;
	bool musicEnabled;
	
	void Start() {
		DebrisTracker.QUEUE_LIMIT = PlayerPrefs.GetInt("Debris Limit", 5);
		setSound(PlayerPrefs.GetInt("soundEnabled", 1) == 1);
		setMusic(PlayerPrefs.GetInt("musicEnabled", 1) == 1);
	}
	
	void OnDestroy() {
		PlayerPrefs.SetInt("Debris Limit", DebrisTracker.QUEUE_LIMIT);
		PlayerPrefs.SetInt("soundEnabled", soundEnabled ? 1 : 0);
		PlayerPrefs.SetInt("musicEnabled", musicEnabled ? 1 : 0);
	}
	
	void setSound(bool v) {
		soundEnabled = v;
	}
	
	void setMusic(bool v) {
		musicEnabled = v;
	}
	
	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if(paused) {
				Unpause();
			}
			else {
				Pause();
			}
		}
	}
	
	void Pause() {
		Time.timeScale = 0;
		paused = true;
		Screen.lockCursor = false;
	}
	
	void Unpause() {
		Time.timeScale = 1;
		paused = false;
		Screen.lockCursor = true;
	}
	
	string QualityString() {
		return QualitySettings.names[ QualitySettings.GetQualityLevel() ];
	}
	
	void OnGUI() {
		if(!paused) {
			return;
		}
		
		int height = 300;
		int width = 300;
		Rect rect = new Rect( Screen.width/2 - width/2, Screen.height/2 - height/2, width, height);
		
		//GUI.Box(rect, "");
		
		GUILayout.BeginArea( rect );
		GUILayout.BeginVertical(GUI.skin.box);
		
			GUILayout.Label("Options");
		
			GUILayout.Space(10);
		
			if(GUILayout.Button("Sound is: " + (soundEnabled ? "On" : "Off"))) {
				setSound(!soundEnabled);
			}
		
			if(GUILayout.Button("Music is: " + (musicEnabled ? "On" : "Off"))) {
				setMusic(!musicEnabled);
			}
		
			GUILayout.Space(10);

			GUILayout.BeginHorizontal();
				GUILayout.Label("Graphic Level: " + QualityString());
				if(GUILayout.Button("More")) {
					QualitySettings.IncreaseLevel();
				}
				if(GUILayout.Button("Less")) {
					QualitySettings.DecreaseLevel();
				}
			GUILayout.EndHorizontal();
		
			GUILayout.Space(10);
		
			GUILayout.BeginHorizontal();
				GUILayout.Label("Debris Amount: " + DebrisTracker.QUEUE_LIMIT);
				if(GUILayout.Button("More")) {
					DebrisTracker.QUEUE_LIMIT++;
				}
				if(GUILayout.Button("Less")) {
					if(DebrisTracker.QUEUE_LIMIT > 0) {
						DebrisTracker.QUEUE_LIMIT--;
					}
				}
			GUILayout.EndHorizontal();
		
			GUILayout.Space(10);
		
			if(GUILayout.Button("Return to Game")) {
				Unpause();
			}
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}
