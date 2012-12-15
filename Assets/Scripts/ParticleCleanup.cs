using UnityEngine;
using System.Collections;

public class ParticleCleanup : MonoBehaviour {
	
	ParticleSystem ps;
	bool hasStarted = false;
	
	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(hasStarted && ps.particleCount == 0) {
			Destroy(gameObject);
		}
		else if(ps.particleCount > 0){
			hasStarted = true;
		}
	}
}
