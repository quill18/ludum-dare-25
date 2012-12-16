using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {
	
	public GameObject[] debris;
	float impactForceLimit = 2f;
	public bool countsTowardsScore = true;
	public static int numDestroyables;
	bool isDestroyed = false;
	
	public AudioClip deathSound;
	
	public AudioClip deployTanksClip;
	
	public int pointValue = 100;
	
	// Use this for initialization
	void Start () {
		if(countsTowardsScore) {
			numDestroyables++;
		}
	}
	
	void OnDestroy() {
		if(countsTowardsScore) {
			numDestroyables--;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		if(collision.impactForceSum.magnitude > impactForceLimit) {
			//Debug.Log (collision.impactForceSum.magnitude);
			DestroyMe();
		}
	}
	
	public void DestroyMe() {
		if(isDestroyed) {
			return;
		}
		
		if(Intersection.spawningEnabled == false) {
			Intersection.spawningEnabled = true;
			if(deployTanksClip) {
				AudioSource.PlayClipAtPoint(deployTanksClip, transform.position);
			}
		}
		
		isDestroyed = true;
		
		foreach(GameObject d in debris) {
			Instantiate(d, transform.position, transform.rotation);
		}
		
		Destroy(gameObject);
		
		if(countsTowardsScore) {	// Misnamed: This is "counts towards victory"
			CityHealth.LoseHealth();
		}
		
		Score.AddPoints( pointValue );
		
		if(deathSound) {
			AudioSource.PlayClipAtPoint(deathSound, transform.position);
		}
		
	}
}
