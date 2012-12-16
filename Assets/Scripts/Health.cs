using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	float health = 100f;
	GUITexture texHealth;
	float trueHealthBarWidth;
	
	public AudioClip hurtClip;
	public AudioClip healClip;
	
	// Use this for initialization
	void Start () {
		texHealth = GameObject.Find ("guiPlayerHealthBar").GetComponent<GUITexture>();
		trueHealthBarWidth = texHealth.pixelInset.width;
	}
	
	// Update is called once per frame
	void Update () {
		Rect p = texHealth.pixelInset;
		p.width = trueHealthBarWidth * health / 100f;
		texHealth.pixelInset = p;
	}
	
	public void TakeDamage(float amt) {
		health -= amt;
		DamageFlash.Flash();
		AudioSource.PlayClipAtPoint(hurtClip, transform.position);
		
		if(health <=0) {
			// TODO: Death animation?
			
			PlayerPrefs.SetInt("Victory", 0);
			Application.LoadLevel("gameOver");
		}
	}
	
	public void Heal() {
		health += 25;
		health = Mathf.Min (health, 100f);
		AudioSource.PlayClipAtPoint(healClip, transform.position);
	}
}
