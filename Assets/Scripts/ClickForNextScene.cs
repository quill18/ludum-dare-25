using UnityEngine;
using System.Collections;

public class ClickForNextScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Screen.lockCursor = true;
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	
	}
}
