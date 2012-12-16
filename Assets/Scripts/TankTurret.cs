using UnityEngine;
using System.Collections;

public class TankTurret : MonoBehaviour {
	
	float fireCooldown = 5f;
	float maxRange = 50f;
	float cooldownRemaining = 0;
	public GameObject missile;
	float turnRate = 360;
	
	// Use this for initialization
	void Start () {
		enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.deltaTime == 0) {
			return;
		}
		
		Transform playerTransform = GameObject.Find("Player").transform;
		Vector3 playerPoint = playerTransform.collider.bounds.center;
		
		Vector3 firePoint = transform.Find("FirePoint").transform.position;
		
		cooldownRemaining -= Time.deltaTime;
		
		// Rotate to face player
		Vector3 dirToPlayer = playerPoint - firePoint;
		
		dirToPlayer.y = 0;
	//	transform.rotation = Quaternion.LookRotation(dirToPlayer);
		Quaternion targetRotation = Quaternion.LookRotation(dirToPlayer);
		transform.rotation = Quaternion.RotateTowards( transform.rotation, targetRotation, turnRate * Time.deltaTime);
			
		// Check line of fire
		dirToPlayer = playerPoint - firePoint;  // Recalc due to Y reset
		if(dirToPlayer.magnitude <= maxRange && Quaternion.Angle(transform.rotation, targetRotation) < 5f) {
			//Ray ray = new Ray(firePoint, dirToPlayer);
			RaycastHit hit;
			//if( Physics.Raycast(ray, out hit, dirToPlayer.magnitude) ) {
			if( Physics.SphereCast(firePoint, 1f, dirToPlayer, out hit, dirToPlayer.magnitude) ) {
				if(hit.collider.transform == playerTransform && cooldownRemaining<=0) {
					Fire();
					cooldownRemaining = fireCooldown;
				}
			}
		}
	}
	
	void Fire() {
		Transform firePoint = transform.Find("FirePoint");
		Instantiate(missile, firePoint.position, firePoint.rotation);
		
		if(audio) {
			audio.Play();
		}
	}
}
