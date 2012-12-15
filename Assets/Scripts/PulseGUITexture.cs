using UnityEngine;
using System.Collections;

public class PulseGUITexture : MonoBehaviour {
	
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Color c = guiTexture.color;
		c.a = Mathf.Abs( Mathf.Sin(Time.time * 2) ) / 2.5f + .1f;
		
		guiTexture.color = c;
		
		if(Input.GetMouseButtonDown(0)) {
			Screen.lockCursor = true;
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
