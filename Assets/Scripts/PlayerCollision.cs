using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	void OnControllerColliderHit( ControllerColliderHit hit ) {
		if(hit.collider.tag == "Bullet") {
			//Debug.Log ("Player Hit!");
		}
	}
	
	void OnCollisionEnter( Collision collision ) {
		if(collision.collider.tag == "Bullet") {
			//Debug.Log ("Player Hit 2!");
		}
	}
}
