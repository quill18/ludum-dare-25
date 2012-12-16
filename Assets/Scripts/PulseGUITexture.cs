using UnityEngine;
using System.Collections;

public class PulseGUITexture : MonoBehaviour {
	
	public bool expires = false;
	public float lifeSpan = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(expires) {
			lifeSpan -= Time.deltaTime;
			if(lifeSpan < 0) {
				Destroy(gameObject);
			}
		}
		
		Color c = guiTexture.color;
		c.a = Mathf.Abs( Mathf.Sin(Time.time * 2) ) / 2.5f + .1f;
		
		guiTexture.color = c;
		
	}
}
