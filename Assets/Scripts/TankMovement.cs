using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour {
	
	public Transform toIntersection;
	float turnRate = 90f;
	float speed = 10f;
	float gravity = -50f;
	float minRange = 1f;

	// Use this for initialization
	void Start () {
	}
	
	void OnDestroy() {
		Intersection.TankDied();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dirToTarget = toIntersection.position - transform.position;
		dirToTarget.y = 0;

		if(dirToTarget.magnitude < minRange) {
			FindNewIntersection();
		} else if(transform.position.y > 0) {
			transform.Translate( Vector3.up * gravity * Time.deltaTime );
			if (transform.position.y < 0) {
				Vector3 pos = transform.position;
				pos.y = 0;
				transform.position = pos;
			}
		} else {
			Quaternion targetRotation = Quaternion.LookRotation(dirToTarget);
			float angle = Quaternion.Angle(transform.rotation, targetRotation);
			
			if(angle > 0) {
				transform.rotation = Quaternion.RotateTowards( transform.rotation, targetRotation, turnRate * Time.deltaTime);
			}
			else {
				transform.Translate( Vector3.forward * speed * Time.deltaTime );
				
			}
		}
	}
	
	void FindNewIntersection() {
		Intersection intersection = toIntersection.GetComponent<Intersection>();
		toIntersection = intersection.GetRandomConnection();
	}
}
