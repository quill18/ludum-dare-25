using UnityEngine;
using System.Collections;

public class DebrisTracker : MonoBehaviour {
	
	static int debrisInstances = 0;

	// Use this for initialization
	void Start () {
		debrisInstances++;
	}
	
	void OnDestroy() {
		debrisInstances--;
	}

	public static bool SafeToCreate() {
		if(debrisInstances < 10) {
			return true;
		}
		
		return false;
	}
}
