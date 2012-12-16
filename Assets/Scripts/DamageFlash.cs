using UnityEngine;
using System.Collections;

public class DamageFlash : MonoBehaviour {

	static DamageFlash instance;
	float flashTime = 1f;
	float flashTimeRemaining = 0;
	
	// Use this for initialization
	void Start () {
		if(instance==null) {
			instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(flashTimeRemaining > 0) {
			flashTimeRemaining -= Time.deltaTime;
			flashTimeRemaining = Mathf.Max(flashTimeRemaining, 0);
	
			Color c = guiTexture.color;
			c.a = flashTimeRemaining / flashTime / 2;
			guiTexture.color = c;
		}
	}
	
	public static void Flash() {
		instance.flashTimeRemaining = instance.flashTime;
	}
}
