using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {
	
	public float timer = 2f;
	public float afterLife = 1f;
	public float disappearSpeed = 2f;
	
	bool didKinematic = false;

	// Use this for initialization
	void Start () {
		//timer = timer * Random.Range(1f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= -afterLife) {
			Destroy(gameObject);
		} else if(timer <= 0) {
			
			if(!didKinematic) {
				didKinematic = true;
				Rigidbody[] rbs = gameObject.GetComponentsInChildren<Rigidbody>() as Rigidbody[];
				foreach (Rigidbody rb in rbs) {
					rb.isKinematic = true;
				}
				
				if(rigidbody) {
					rigidbody.isKinematic = true;
				}
			}
			
			transform.Translate( -Vector3.up * disappearSpeed * Time.deltaTime, Space.World );
		}

	}
}
