using UnityEngine;
using System.Collections;

public class MouseLocker : MonoBehaviour {

	// Use this for initialization
	void Start () {
					Screen.lockCursor = true;

	}
	
	// Update is called once per frame
	void Update () {

	}
	
	/*void OnGUI() {
		if(GUI.Button(new Rect(0,0,50,50), "Lock")) {
			Screen.lockCursor = true;
		}
	}*/
}
