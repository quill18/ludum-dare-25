using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {
	
	public GameObject debris;
	float impactForceLimit = 2f;
	public bool countsTowardsScore = true;
	public static int numDestroyables;
	bool isDestroyed = false;
	
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
		
		isDestroyed = true;
		
		if(debris != null) {
			Instantiate(debris, transform.position, transform.rotation);
		}
		
		Destroy(gameObject);
		
		if(countsTowardsScore) {
			CityHealth.LoseHealth();
		}
	}
}
