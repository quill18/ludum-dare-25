using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {
	
	float timer = 2f;

	// Use this for initialization
	void Start () {
		timer = timer * Random.Range(1f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer <= 0) {
			Destroy(gameObject);
		}
	}
}
