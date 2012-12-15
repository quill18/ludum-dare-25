using UnityEngine;
using System.Collections;

public class StretchGUITexture : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GUITexture t = GetComponent<GUITexture>();
		Rect r = t.pixelInset;
		
		float aspect = r.height/ r.width;
		
		r.height = Screen.height;
		r.width = Screen.height / aspect;
		
		r.x = -r.width;
		//r.y = r.height;
		
		t.pixelInset = r;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
