using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	
	float lifeSpan = 0.1f;

	// Update is called once per frame
	void Update () {
		lifeSpan -= Time.deltaTime;
		if(lifeSpan <= 0) {
			Destroy(gameObject);
		}
	}
}
