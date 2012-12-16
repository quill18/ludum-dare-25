using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour {
	
	public Transform toIntersection;
	float turnRate = 90f;
	float speed = 10f;
	float gravity = -50f;
	float minRange = 1f;
	bool enabledTurret = false;

	// Use this for initialization
	void Start () {
	}
	
	void OnDestroy() {
		if(toIntersection != null) {
			Intersection intersection = toIntersection.GetComponent<Intersection>();
			intersection.TankDied();
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dirToTarget = toIntersection.position - transform.position;
		dirToTarget.y = 0;

		if(transform.position.y > 0) {
			transform.Translate( Vector3.up * gravity * Time.deltaTime );
			if (transform.position.y < 0) {
				Vector3 pos = transform.position;
				pos.y = 0;
				transform.position = pos;
			}
		} else {
			if(!enabledTurret) {
				transform.Find("Turret").GetComponent<TankTurret>().enabled = true;
				enabledTurret = true;
				
				GameObject para = transform.Find("parachute").gameObject;//.parent = null;
				para.transform.parent = null;
				SelfDestruct dest = para.AddComponent<SelfDestruct>();
				dest.afterLife = 5;
				dest.timer = 0;
				dest.disappearSpeed = 5;
			}
			
			if(dirToTarget.magnitude < minRange) {
				FindNewIntersection();
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
	}
	
	void FindNewIntersection() {
		Intersection intersection = toIntersection.GetComponent<Intersection>();
		toIntersection = intersection.GetRandomConnection();
	}
}
