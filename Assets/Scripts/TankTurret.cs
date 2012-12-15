using UnityEngine;
using System.Collections;

public class TankTurret : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform playerTransform = GameObject.Find("Player").transform;
		// Rotate to face player
		Vector3 dirToPlayer = playerTransform.position - transform.position;
		dirToPlayer.y = 0;
		transform.rotation = Quaternion.LookRotation(dirToPlayer);
		
		// Check line of fire
		dirToPlayer = playerTransform.position - transform.position;  // Recalc due to Y reset
		Ray ray = new Ray(transform.position, dirToPlayer);
		RaycastHit hit;
		if( Physics.Raycast(ray, out hit, dirToPlayer.magnitude) ) {
			if(hit.collider.transform == playerTransform) {
				//Fire();
			}
		}
	}
}
