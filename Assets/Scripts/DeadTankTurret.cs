using UnityEngine;
using System.Collections;

public class DeadTankTurret : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.AddForce( new Vector3( Random.Range(-5f,5f) , 10, Random.Range(-5f,5f) ), ForceMode.Impulse );
		rigidbody.AddTorque( Random.onUnitSphere * 50f );
	}

}
