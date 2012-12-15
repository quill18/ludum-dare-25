using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour {
	
	float range = 20.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
		if( Input.GetButtonDown("Fire1") ) {
			Vector3 dir = Camera.main.transform.forward;
			RaycastHit hitInfo;
			if( Physics.Raycast( transform.position, dir, out hitInfo, range ) ) {
				Destroyable dest = hitInfo.collider.gameObject.GetComponent<Destroyable>();
				if(dest != null) {
					dest.DestroyMe();
				}
			}
		}
	}
	
	
}
