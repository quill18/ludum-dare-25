using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
	
	float speed = 5f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate( Vector3.up * speed * Time.deltaTime );
	}
	
	void OnCollisionEnter() {
		Debug.Log ("MISSILE HIT!");
		Destroy(gameObject);
	}
}
