using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate( 0, 360 * Time.deltaTime, 0);
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log ("Trigger!");
		Health h = other.GetComponent<Health>();
		if(h) {
			h.Heal();
			Destroy(gameObject);
		}
	}
	
}
