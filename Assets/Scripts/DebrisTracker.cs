using UnityEngine;
using System.Collections;

public class DebrisTracker : MonoBehaviour {

	static ArrayList debrisQueue;
	static int debrisSelfDestructing = 0;
	public static int QUEUE_LIMIT = 5;
	
	bool selfDestructing = false;
	float disappearSpeed = 0;

	// Use this for initialization
	void Start () {
		if(debrisQueue == null) {
			debrisQueue = new ArrayList();
		}
		
		debrisQueue.Add(this);
		
		while(debrisQueue.Count > QUEUE_LIMIT) {
			DebrisTracker dt = (DebrisTracker)debrisQueue[0];
			debrisQueue.RemoveAt(0);
			dt.SelfDestruct();
		}
	}
	
	void OnDestroy() {
		debrisQueue.Remove(this);
	}
	
	void SelfDestruct() {
		if(debrisSelfDestructing >= QUEUE_LIMIT*2) {
			Destroy(gameObject);
			return;
		}
		
		debrisSelfDestructing++;
		
		selfDestructing = true;
		/*Rigidbody[] rbs = gameObject.GetComponentsInChildren<Rigidbody>() as Rigidbody[];
		foreach (Rigidbody rb in rbs) {
			rb.isKinematic = true;
		}*/
		
		Collider[] cs = gameObject.GetComponentsInChildren<Collider>() as Collider[];
		foreach (Collider c in cs) {
			c.enabled = false;
		}
		
		/*if(rigidbody) {
			rigidbody.isKinematic = true;
		}*/
		if(collider) {
			collider.enabled = false;
		}
	}
	
	void Update() {
		if(selfDestructing) {
			disappearSpeed += Physics.gravity.y * Time.deltaTime;
			transform.Translate( Vector3.up * disappearSpeed * Time.deltaTime, Space.World );
			
			if(transform.position.y < -5) {
				Destroy(gameObject);
				debrisSelfDestructing--;
			}
		}
	}

}
