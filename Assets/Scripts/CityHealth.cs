using UnityEngine;
using System.Collections;

public class CityHealth : MonoBehaviour {

	static float currHealth;
	static float maxHealth;
	GUITexture texHealth;
	float trueHealthBarWidth;
	bool setupDone = false;
	
	// Use this for initialization
	void Start () {
	}
	
	void Setup() {
		texHealth = GameObject.Find ("guiCityHealthBar").GetComponent<GUITexture>();
		trueHealthBarWidth = texHealth.pixelInset.width;
		
		/*Destroyable[] dests = GameObject.FindObjectsOfType(typeof(Destroyable)) as Destroyable[];
		
		foreach(Destroyable d in dests) {
			Debug.Log (d.name);
		}*/
		
		maxHealth = Destroyable.numDestroyables; //dests.Length;
		currHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(!setupDone) {
			Setup ();
			setupDone = true;
		}
		
		
		if(maxHealth <= 0) {
			Debug.LogError("City has zero max health?");
			return;
		}
		
		Rect p = texHealth.pixelInset;
		
		float health = currHealth / maxHealth;
		
		//Debug.Log (currHealth) ;
		
		p.width = trueHealthBarWidth * health;
		texHealth.pixelInset = p;
	}
	
	static public void LoseHealth() {
		currHealth -= 1;
		if(currHealth <=0) {
			// TODO: Win animation?
			
			Application.LoadLevel("gameOver-Win");
		}
	}
}
