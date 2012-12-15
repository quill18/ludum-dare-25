using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {
	
	public GameObject debris;
	float impactForceLimit = 2f;
	
	// Use this for initialization
	void Start () {
	
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
		if(debris != null) {
			Instantiate(debris, transform.position, transform.rotation);
		}
		
		Destroy(gameObject);
	}
}
